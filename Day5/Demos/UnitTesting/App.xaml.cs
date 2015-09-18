using System;
using System.Collections.Generic;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Linq;
using WpfAddressBook.Interfaces;
using WpfAddressBook.ViewModels;

namespace WpfAddressBook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : System.Windows.Application
    {
	    public App()
	    {
		    IoC.Instance.Register(typeof(IDatabase),typeof(RealDatabase));
	    }
    }

	public class RealDatabase : IDatabase
	{
		public void Save(IEnumerable<ContactViewModel> contacts)
		{
			MessageBox.Show(string.Format("Save {0} records to the database", contacts.Count()));
		}
	}
}