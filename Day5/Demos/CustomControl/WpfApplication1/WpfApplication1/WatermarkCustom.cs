using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApplication1
{
	/// <summary>
	/// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
	///
	/// Step 1a) Using this custom control in a XAML file that exists in the current project.
	/// Add this XmlNamespace attribute to the root element of the markup file where it is 
	/// to be used:
	///
	///     xmlns:MyNamespace="clr-namespace:WpfApplication1"
	///
	///
	/// Step 1b) Using this custom control in a XAML file that exists in a different project.
	/// Add this XmlNamespace attribute to the root element of the markup file where it is 
	/// to be used:
	///
	///     xmlns:MyNamespace="clr-namespace:WpfApplication1;assembly=WpfApplication1"
	///
	/// You will also need to add a project reference from the project where the XAML file lives
	/// to this project and Rebuild to avoid compilation errors:
	///
	///     Right click on the target project in the Solution Explorer and
	///     "Add Reference"->"Projects"->[Browse to and select this project]
	///
	///
	/// Step 2)
	/// Go ahead and use your control in the XAML file.
	///
	///     <MyNamespace:WatermarkCustom/>
	///
	/// </summary>

	[TemplatePart(Name = "PART_txtBox", Type = typeof(TextBox))]
	[TemplatePart(Name = "PART_watermarkTxtBlock", Type = typeof(TextBlock))]
	public class WatermarkCustom : Control
	{
		public static readonly DependencyProperty CustomWatermarkTextProperty = DependencyProperty.Register(
			"CustomWatermarkText", typeof(string), typeof(WatermarkCustom), new PropertyMetadata(default(string)));

		public string CustomWatermarkText
		{
			get { return (string)GetValue(CustomWatermarkTextProperty); }
			set { SetValue(CustomWatermarkTextProperty, value); }
		}


		static WatermarkCustom()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(WatermarkCustom), new FrameworkPropertyMetadata(typeof(WatermarkCustom)));
		}

		private TextBox txtBox;
		private TextBlock txtBlock;

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			txtBox = (TextBox)Template.FindName("PART_txtBox",this);
			if (txtBox == null)
			{
				this.IsEnabled = false;
			}
			else
			{
				txtBox.GotFocus += TxtBox_GotFocus;
				txtBox.LostFocus += TxtBox_LostFocus;
				txtBlock = (TextBlock)Template.FindName("PART_watermarkTxtBlock", this);
			}
		}


		private void TxtBox_LostFocus(object sender, RoutedEventArgs e)
		{

			if (string.IsNullOrWhiteSpace(txtBox.Text))
			{
				txtBlock.Text = CustomWatermarkText;
			}
		}

		private void TxtBox_GotFocus(object sender, RoutedEventArgs e)
		{
			txtBlock.Text = "";
		}

	
	}
}
