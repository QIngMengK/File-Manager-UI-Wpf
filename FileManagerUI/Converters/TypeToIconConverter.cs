using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace FileManagerUIWpf.Converters {
    public class TypeToIconConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is not DirectoryItemType type) return null;

            return type switch {
                DirectoryItemType.Drive => new BitmapImage(new Uri("pack://application:,,,/Resources/Images/drive.png")),
                DirectoryItemType.Folder => new BitmapImage(new Uri("pack://application:,,,/Resources/Images/folder.png")),
                _ => new BitmapImage(new Uri("pack://application:,,,/Resources/Images/file.png"))
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}