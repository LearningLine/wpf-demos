using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
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

namespace DispatcherDemo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			//BackgroundWorker bw = new BackgroundWorker();
			//bw.DoWork += ChangeButtonText;
			//bw.RunWorkerAsync();

			//bool IAmOnTheUIThread = myButton.Dispatcher.CheckAccess();
			//if (IAmOnTheUIThread)
			//{
			//	//On Response update list of posts
			//	myButton.Content = "Value from backgroud thread";
			//}

			var myString = MyAsyncMethod().Result;
			//Next line
			MessageBox.Show(myString);
		}

		//private void ChangeButtonText(object sender, DoWorkEventArgs e)
		//{
		//	//Fetch FB posts
		//	bool IAmOnTheUIThread = myButton.Dispatcher.CheckAccess();
		//	if (IAmOnTheUIThread)
		//	{
		//		//On Response update list of posts
		//		myButton.Content = "Value from backgroud thread";
		//	}
		//	else
		//	{
		//		myButton.Dispatcher.Invoke(() =>
		//		{
		//			myButton.Content = "Value from bacgkround thread";
		//		});
		//	}

		//}


		private async Task<string> MyAsyncMethod()
		{
			//Som long running task
			await Task.Factory.StartNew(() =>
			{
				Thread.Sleep(10);
			});
			return "done";
		}

	}
}
