using System;
using System.IO;
using System.ComponentModel;
using System.Windows.Media;

namespace Explorer
{
    /// <summary>
    /// This class models a single file entry.
    /// </summary>
    public class FileInfo : IFileSystemEntry, INotifyPropertyChanged
    {
        private string _fullName;
        readonly ImageSource _icon;

        public FileInfo() 
        { 
        }
        
        public FileInfo(string fn)
        {
            FullName = fn;
            _icon = Win32.LoadIcon(FullName);
        }

        public string Name
        {
            get 
            { 
                return Path.GetFileName(FullName); 
            }

            set
            {
                string oldFullName = FullName;
                string newFullName = Path.Combine(Path.GetDirectoryName(_fullName), value);
                File.Move(oldFullName, newFullName);
                FullName = newFullName;
            }
        }

        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                OnPropertyChanged();

            }
        }

        private void OnPropertyChanged()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("FullName"));
                PropertyChanged(this, new PropertyChangedEventArgs("Icon"));
                PropertyChanged(this, new PropertyChangedEventArgs("IsReadOnly"));
                PropertyChanged(this, new PropertyChangedEventArgs("LastAccessTime"));
            }
        }

        public DateTime CreationTime
        {
            get
            {
                return File.GetCreationTime(FullName);
            }
        }

        public ImageSource Icon
        {
            get
            {
                return _icon;
            }
        }

        public DateTime LastAccessTime
        {
            get
            {
                return File.GetLastAccessTime(FullName);
            }
        }
        
        public bool IsReadOnly
        {
            get
            {
                return (File.GetAttributes(FullName) & FileAttributes.ReadOnly) != 0;
            }
            set
            {
                if (value)
                    Attributes |= FileAttributes.ReadOnly;
                else
                    Attributes &= ~FileAttributes.ReadOnly;
            }
        }
        
        FileAttributes Attributes
        {
            get
            {
                return File.GetAttributes(FullName);
            }
            set
            {
                File.SetAttributes(FullName, value);
            }
        }
        
        public bool Exists
        {
            get
            {
                return File.Exists(FullName);
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
