using System;

namespace FileManagerUIWpf.Model {
    public class DirectoryItem {
        public string Name { get; set; }     // 显示名称 (示例："Documents")
        public string FullPath { get; set; } // 完整路径 (示例："C:\Users\Admin\Documents")
        public DirectoryItemType Type { get; set; } // 类型标识
        public DateTime? LastModified { get; set; } // 最后修改时间
        public long? Size { get; set; }       // 文件大小（仅文件有效）
    }

    public enum DirectoryItemType {
        Drive,   // 磁盘驱动器
        Folder,  // 文件夹
        File     // 文件
    }
}