using System.Windows;

namespace CoolButton
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        void OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You clicked a button!");
        }
    }
}
