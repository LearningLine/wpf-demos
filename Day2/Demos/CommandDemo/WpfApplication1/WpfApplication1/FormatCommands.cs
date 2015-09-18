using System.Collections.Generic;
using System.Windows.Input;

namespace WpfApplication1
{
	public static class FormatCommands
	{
		static RoutedUICommand setBackground = new RoutedUICommand("Set the Background",
			"SetBackground",typeof(FormatCommands),new InputGestureCollection(
				new List<InputGesture>
				{
					new KeyGesture(Key.D,ModifierKeys.Alt)
				}));

		public static RoutedUICommand SetBackground {  get {  return setBackground;} }
	}
}
