using System.Collections.ObjectModel;
using System.Linq;
using DataProviders;

namespace ViewModels
{
	public class EmployeesViewModel : BaseViewModel
	{
		public ObservableCollection<EmployeeViewModel> Employees { get; set; }

		public EmployeesViewModel()
		{
			var dp = new DataProvider();
			var employeeModels = dp.GetEmployees()
				.Select(x => new EmployeeViewModel(x));

			Employees = new ObservableCollection<EmployeeViewModel>(employeeModels);
		}
	}
}