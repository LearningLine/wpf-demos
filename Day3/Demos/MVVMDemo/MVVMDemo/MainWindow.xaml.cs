using System.Windows;
using ViewModels;

namespace MVVMDemo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			DataContext = new EmployeesViewModel();
			InitializeComponent();
		}
	}
}
