using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApplication1
{
	/// <summary>
	/// Interaction logic for DPControl.xaml
	/// </summary>
	public partial class DPControl : UserControl
	{
		public DPControl()
		{
			InitializeComponent();
		}

		public static readonly DependencyProperty BProperty = DependencyProperty.Register(
			"B", typeof (bool), typeof (DPControl), 
			new FrameworkPropertyMetadata(false,OnPropertyChanged));

		private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var myControl = (DPControl) d;
			if ((bool) e.NewValue)
			{
				myControl.myRect.Fill = new SolidColorBrush(Colors.Green);
			}
			else
			{
				myControl.myRect.Fill = new SolidColorBrush(Colors.Black);
			}
		}

		public bool B
		{
			get { return (bool) GetValue(BProperty); }
			set { SetValue(BProperty, value); }
		}
	}
}
