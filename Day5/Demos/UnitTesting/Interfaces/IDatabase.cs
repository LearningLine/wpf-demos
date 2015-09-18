using System.Collections.Generic;
using WpfAddressBook.ViewModels;

namespace WpfAddressBook.Interfaces
{
	public interface IDatabase
	{
		void Save(IEnumerable<ContactViewModel> contacts);
	}
}
