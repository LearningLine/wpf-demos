using System;
using System.Windows;
using System.Windows.Controls;

namespace EventDemo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.PreviewMouseDown += MainWindow_PreviewMouseDown;
			button3.Click += Button3_Click;
		}

		private void MainWindow_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			if (e.Source is Button)
			{
				Console.WriteLine("About to click a button");
				//e.Handled = true;
			}
			else
			{
				Console.WriteLine("You clicked something elese");
			}
		}

		private void Button3_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Clicked button 3");
			e.Handled = true;
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("You clicked a button");
		}

		private void MainWindow_OnClick(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("I am the windows eating your clicks");
		}
	}
}
