using System;
using System.Collections.Generic;
using Models;

namespace DataProviders
{
    public class DataProvider
    {
	    public List<Employee> GetEmployees()
	    {
		    return new List<Employee>
		    {
			    new Employee()
			    {
				    FirstName = "Brad",
				    LastName = "Cunningham"
			    },
			    new Employee()
			    {
				    FirstName = "Joe",
				    LastName = "Smith",
				    TerminatedDate = DateTime.Now,
					Manager = new Employee { FirstName = "Manager", LastName = "Guy" }
			    }
		    };
	    } 
    }
}
