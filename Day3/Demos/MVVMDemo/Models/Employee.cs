using System;

namespace Models
{
    public class Employee
    {
	    public string FirstName { get; set; }
	    public string LastName { get; set; }
	    public DateTime? TerminatedDate { get; set; }
	    public Employee Manager { get; set; }
    }


}
