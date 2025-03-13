using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using FileManagerUIWpf.Model;
using GalaSoft.MvvmLight.Command;

namespace FileManagerUIWpf.ViewModel {
    public class MainViewModel : ViewModelBase {
        #region 属性
        private string _currentPath;
        public string CurrentPath {
            get => _currentPath;
            set {
                if (Set(ref _currentPath, value)) {
                    // 路径改变时自动加载内容
                    LoadDirectoryContents();
                    // 更新历史记录
                    PathHistory.Add(value);
                    CurrentHistoryIndex = PathHistory.Count - 1;
                }
            }
        }

        private ObservableCollection<DirectoryItem> _items = new();
        public ObservableCollection<DirectoryItem> Items {
            get => _items;
            set => Set(ref _items, value);
        }

        public ObservableCollection<string> PathHistory { get; } = new();
        private int _currentHistoryIndex = -1;
        #endregion

        #region 命令
        public ICommand GoBackCommand => new RelayCommand(
            () => CurrentHistoryIndex--,
            () => CurrentHistoryIndex > 0);

        public ICommand GoForwardCommand => new RelayCommand(
            () => CurrentHistoryIndex++,
            () => CurrentHistoryIndex < PathHistory.Count - 1);

        public ICommand NavigateCommand => new RelayCommand<string>(path => CurrentPath = path);
        #endregion

        public MainViewModel() {
            // 初始化加载所有驱动器
            LoadDrives();
        }

        #region 核心方法
        private void LoadDrives() {
            Items.Clear();
            foreach (var drive in DriveInfo.GetDrives().Where(d => d.IsReady)) {
                Items.Add(new DirectoryItem {
                    Name = $"{drive.Name} ({drive.VolumeLabel})",
                    FullPath = drive.RootDirectory.FullName,
                    Type = DirectoryItemType.Drive,
                    LastModified = DateTime.Now,
                    Size = drive.TotalSize - drive.AvailableFreeSpace
                });
            }
        }

        private async void LoadDirectoryContents() {
            IsLoading = true;
            Items.Clear();

            try {
                await Task.Run(() => {
                    // 添加上级目录
                    if (Directory.Exists(CurrentPath) &&
                        Directory.GetParent(CurrentPath) != null) {
                        Application.Current.Dispatcher.Invoke(() => {
                            Items.Add(CreateParentDirectoryItem());
                        });
                    }

                    // 加载子目录
                    foreach (var dir in Directory.EnumerateDirectories(CurrentPath)) {
                        var dirInfo = new DirectoryInfo(dir);
                        Application.Current.Dispatcher.Invoke(() => {
                            Items.Add(new DirectoryItem {
                                Name = dirInfo.Name,
                                FullPath = dirInfo.FullName,
                                Type = DirectoryItemType.Folder,
                                LastModified = dirInfo.LastWriteTime
                            });
                        });
                    }

                    // 加载文件
                    foreach (var file in Directory.EnumerateFiles(CurrentPath)) {
                        var fileInfo = new FileInfo(file);
                        Application.Current.Dispatcher.Invoke(() => {
                            Items.Add(new DirectoryItem {
                                Name = fileInfo.Name,
                                FullPath = fileInfo.FullName,
                                Type = DirectoryItemType.File,
                                LastModified = fileInfo.LastWriteTime,
                                Size = fileInfo.Length
                            });
                        });
                    }
                });
            }
            catch (UnauthorizedAccessException ex) {
                ShowErrorMessage($"访问被拒绝: {ex.Message}");
            }
            finally {
                IsLoading = false;
            }
        }

        private DirectoryItem CreateParentDirectoryItem() => new() {
            Name = "..",
            FullPath = Directory.GetParent(CurrentPath)?.FullName,
            Type = DirectoryItemType.Folder
        };
        #endregion
    }
}