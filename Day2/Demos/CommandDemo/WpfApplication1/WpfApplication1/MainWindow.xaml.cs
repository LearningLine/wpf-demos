using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApplication1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.InputBindings.Add(new InputBinding(FormatCommands.SetBackground,
				new KeyGesture(Key.K, ModifierKeys.Control)));
		}

		private void CommandBinding_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			RichTextBox rtb = (RichTextBox) sender;
			if (rtb.Selection.IsEmpty)
			{
				e.CanExecute = false;
			}
			else
			{
				e.CanExecute = true;
			}
		}

		private void CommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			RichTextBox rtb = (RichTextBox)sender;
			rtb.Selection.ApplyPropertyValue(TextElement.BackgroundProperty,
				Brushes.Green);

		}
	}
}
