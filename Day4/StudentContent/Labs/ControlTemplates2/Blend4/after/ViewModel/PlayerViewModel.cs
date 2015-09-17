using System.Diagnostics;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using JulMar.Windows.Mvvm;
using VideoViewer.Model;
using System.Windows.Media.Effects;
using System.Collections.Generic;
using System.Reflection;
using System;

namespace VideoViewer.ViewModel
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        public List<EffectViewModel> Effects { get; private set; }
        private EffectViewModel _selectedEffect;
        public EffectViewModel SelectedEffect
        {
            get { return _selectedEffect; }
            set { _selectedEffect = value; OnPropertyChanged("SelectedEffect"); }
        }

        public ObservableCollection<VideoViewModel> Videos { get; private set; }

        private VideoViewModel _selectedVideo;
        public VideoViewModel SelectedVideo
        {
            get { return _selectedVideo; }
            set
            {
                _selectedVideo = value;
                OnPropertyChanged("SelectedVideo");
                OnPropertyChanged("VideoUrl");
            }
        }

        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set { _searchTerm = value; OnPropertyChanged("SearchTerm"); }
        }

        public string VideoUrl
        {
            get
            {
                return (_selectedVideo != null) ? _selectedVideo.Url : null;
            }
        }

        public ICommand SearchCommand { get; private set; }

        public PlayerViewModel()
        {
            Videos = new ObservableCollection<VideoViewModel>();
            SearchCommand = new DelegatingCommand(OnSearch);
            Effects = new List<EffectViewModel> { new EffectViewModel { Name = "None", Effect = null } };

            Assembly psasm = Assembly.LoadFrom("ShaderEffectLibrary.dll");
            if (psasm != null)
            {
                var effects = from type in psasm.GetTypes()
                              where type.IsSubclassOf(typeof(ShaderEffect))
                              select new EffectViewModel
                              {
                                  Name = type.Name,
                                  Effect = (ShaderEffect)Activator.CreateInstance(type)
                              };
                Effects.AddRange(effects);
            }

        }

        void OnSearch()
        {
            Videos.Clear();
            SelectedVideo = null;

            var newVideos = VideoFinder.FindVideos(SearchTerm);
            foreach (var video in newVideos)
                Videos.Add(new VideoViewModel(video));

            if (Videos.Count > 0)
                SelectedVideo = Videos[0];
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
