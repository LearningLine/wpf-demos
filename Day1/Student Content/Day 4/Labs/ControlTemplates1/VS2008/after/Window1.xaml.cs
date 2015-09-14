using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace CoolButton
{
	public partial class Window1 : Window
	{
		public Window1()
		{
			this.InitializeComponent();
		}

        void OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You clicked a button!");
        }
	}
}
