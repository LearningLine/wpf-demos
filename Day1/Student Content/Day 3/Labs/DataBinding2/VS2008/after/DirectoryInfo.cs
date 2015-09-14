using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media;

namespace Explorer
{
    /// <summary>
    /// This class models a single directory
    /// </summary>
    public class DirectoryInfo : IFileSystemEntry
    {
        private string _fullName;
        private readonly ImageSource _icon;

        public DirectoryInfo()
        {
        }

        public DirectoryInfo(string fn)
        {
            FullName = fn;
            _icon = Win32.LoadIcon(fn);
        }

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        public ImageSource Icon
        {
            get { return _icon; }
        }

        public string Name
        {
            get
            {
                return Path.GetFileName(_fullName);
            }

            set
            {
                string oldName = _fullName;
                string newName = Path.Combine(Path.GetDirectoryName(oldName), value);
                Directory.Move(oldName, newName);
                _fullName = newName;
            }
        }

        public List<IFileSystemEntry> Children
        {
            get
            {
                return SubDirectories.Concat(Files.Cast<IFileSystemEntry>()).ToList();
            }
        }

        public FileInfo[] Files
        {
            get
            {
                return Directory.GetFiles(FullName)
                    .Where(filename => (File.GetAttributes(filename) & (FileAttributes.Hidden | FileAttributes.System | FileAttributes.Temporary)) == 0)
                    .Select(filename => new FileInfo(filename))
                    .ToArray();
            }
        }

        public DirectoryInfo[] SubDirectories
        {
            get
            {
                try
                {
                    return Directory.GetDirectories(FullName)
                        .Where(directory => (File.GetAttributes(directory) & (FileAttributes.Hidden | FileAttributes.System | FileAttributes.Temporary)) == 0)
                        .Select(directory => new DirectoryInfo(directory))
                        .ToArray();
                }
                catch
                {
                    return new DirectoryInfo[0];
                }
            }
        }

        public bool Exists
        {
            get
            {
                return Directory.Exists(FullName);
            }
        }

        public DateTime CreationTime
        {
            get
            {
                return Directory.GetCreationTime(_fullName);
            }
        }
    }
}
