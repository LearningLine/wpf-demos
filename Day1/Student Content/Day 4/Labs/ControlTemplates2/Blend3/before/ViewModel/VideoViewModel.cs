using System.ComponentModel;
using System.Diagnostics;
using VideoViewer.Model;
using System;

namespace VideoViewer.ViewModel
{
    public class VideoViewModel : INotifyPropertyChanged
    {
        private readonly Video _video;

        public string Name
        {
            get { return _video.Name; }   
        }

        public string Url
        {
            get { return _video.Url; }   
        }

        public DateTime PublishDate
        {
            get { return _video.Published; }   
        }

        public VideoViewModel(Video video)
        {
            _video = video;                 
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected void OnPropertyChanged(string propName)
        {
            Debug.Assert(string.IsNullOrEmpty(propName) || GetType().GetProperty(propName) != null);
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        #endregion
    }
}
