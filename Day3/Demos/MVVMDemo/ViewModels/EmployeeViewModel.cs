using System;
using System.Windows.Input;
using Models;

namespace ViewModels
{
	public class EmployeeViewModel : BaseViewModel
	{
		private readonly Employee _model;
		private ICommand _fireEmployeeCommand;

		public EmployeeViewModel(Employee model)
		{
			_model = model;
			FireEmployeeCommand = new DelegateCommand(OnFireEmployeeCommand, _ => true);
		}

		private void OnFireEmployeeCommand(object obj)
		{
			_model.TerminatedDate = DateTime.Now;
			_model.Manager =  new Employee();
			OnPropertyChanged("NotifyManagerOfTermination");
		}

		public string FirstName
		{
			get { return _model.FirstName; }
			set
			{
				if (value != _model.FirstName)
				{
					_model.FirstName = value;
					OnPropertyChanged();
				}
			}
		}

		public string LastName
		{
			get { return _model.LastName; }
			set
			{
				if (value != _model.LastName)
				{
					_model.LastName = value;
					OnPropertyChanged();
				}
			}
		}

		public ICommand FireEmployeeCommand
		{
			get { return _fireEmployeeCommand; }
			set
			{
				_fireEmployeeCommand = value;
			}
		}

		public bool NotifyManagerOfTermination
		{
			get
			{
				return _model.TerminatedDate.HasValue && _model.Manager != null;
			}
		}
	}

	public class DelegateCommand : ICommand
	{
		private readonly Action<object> _execute;
		private readonly Func<object,bool> _canExecute;

		public DelegateCommand(Action<object> execute, Func<object,bool> canExecute)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute(parameter);
		}

		public void Execute(object parameter)
		{
			_execute(parameter);
		}

		public event EventHandler CanExecuteChanged;
	}
}
