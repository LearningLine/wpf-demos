using System.Windows;
using System.Windows.Controls;

namespace StyleSwitch
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : System.Windows.Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        void OnThemeChanged(object sender, RoutedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            string skinName = (string)((ComboBoxItem)cb.SelectedItem).Tag;
            ((App)Application.Current).SkinTheApp(skinName);
        }
    }
}