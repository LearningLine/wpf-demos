using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LayoutDemo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			//myGrid.Children.Add(new Button() {Content = "3", Opacity = .5});
		}

		private Window window2;
		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			//window2 = new Window();
			//window2.Owner = this;
			//window2.Show();

			myContentControl.Content = new Button() {Content = "Save"};
		}
	}
}
