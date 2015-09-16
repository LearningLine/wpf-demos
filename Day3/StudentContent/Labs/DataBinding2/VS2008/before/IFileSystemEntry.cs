using System;
using System.Windows.Media;

namespace Explorer
{
    /// <summary>
    /// Interface modeling a single file/directory entry.
    /// </summary>
    public interface IFileSystemEntry
    {
        string FullName { get; set; }
        ImageSource Icon { get; }
        string Name { get; set; }
        bool Exists { get; }
        DateTime CreationTime { get; }
    }
}