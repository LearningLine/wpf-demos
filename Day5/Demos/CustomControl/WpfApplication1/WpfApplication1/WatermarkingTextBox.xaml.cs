using System.Windows;
using System.Windows.Controls;

namespace WpfApplication1
{
	/// <summary>
	/// Interaction logic for WatermarkingTextBox.xaml
	/// </summary>
	public partial class WatermarkingTextBox : UserControl
	{
		public static readonly DependencyProperty WatermarkTextProperty = DependencyProperty.Register(
			"WatermarkText", typeof (string), typeof (WatermarkingTextBox), new PropertyMetadata(default(string)));

		public string WatermarkText
		{
			get { return (string) GetValue(WatermarkTextProperty); }
			set { SetValue(WatermarkTextProperty, value); }
		}

		public WatermarkingTextBox()
		{
			InitializeComponent();
		}

		private void UIElement_OnGotFocus(object sender, RoutedEventArgs e)
		{
			txtWatermark.Text = "";
		}

		private void UIElement_OnLostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtBox.Text))
			{
				txtWatermark.Text = WatermarkText;
			}
		}
	}
}
