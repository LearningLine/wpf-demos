using System.ComponentModel;
using System.Runtime.CompilerServices;
using BindingDemo.Annotations;

namespace BindingDemo
{
	public class Contact : INotifyPropertyChanged
	{
		private string _firstName;
		private string _lastName;

		public string FirstName
		{
			get { return _firstName; }
			set
			{
				_firstName = value;
				OnPropertyChanged();
				//Also change the last name
				//LastName = "Smith";
				//OnPropertyChanged(nameof(LastName));
			}
		}

		public string LastName
		{
			get { return _lastName; }
			set
			{
				if (value != _lastName)
				{
					_lastName = value;
					OnPropertyChanged();
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}

			//?. is null propagation (only works in VS2015)
			//PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
