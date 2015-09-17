using System;
using System.Windows;
using System.Windows.Controls;
using VideoViewer.ViewModel;

namespace VideoViewer
{
    public partial class Window1
    {
        public Window1()
        {
            DataContext = new PlayerViewModel();
            InitializeComponent();
        }

        void OnDragMove(object sender, RoutedEventArgs e)
        {
            DragMove();
        }

        private void OnClose(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnRestartMedia(object sender, RoutedEventArgs e)
        {
            MediaElement mediaElement = (MediaElement)sender;
            mediaElement.Position = TimeSpan.FromSeconds(0);
        }
    }
}
