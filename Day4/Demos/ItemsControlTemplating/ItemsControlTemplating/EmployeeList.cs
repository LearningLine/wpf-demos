using System.CodeDom;
using System.Collections.ObjectModel;

namespace ItemsControlTemplating
{
	public class EmployeeList
	{
		private ObservableCollection<Employee> _employees;

		public ObservableCollection<Employee> Employees
		{
			get { return _employees; }
			set { _employees = value; }
		}

		public EmployeeList()
		{
			Employees = new ObservableCollection<Employee>();
			Employees.Add(new Employee
			{
				FirstName = "Brad",
				LastName = "Cunningham"
			});
			Employees.Add(new Employee
			{
				FirstName = "Joe",
				LastName = "Smith"
			});
		}
	}

	public class Employee
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
