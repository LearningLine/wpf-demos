using System.Linq;
using ApprovalTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfAddressBook.ViewModels;

namespace ViewModel.Tests
{
	[TestClass]
	public class MainViewModelTests
	{

		private MainViewModel vm;

		[ClassInitialize]
		public static void ClassSetup(TestContext context)
		{
			
		}

		[TestInitialize]
		public void TestSetup()
		{
			vm = new MainViewModel();
		}

		[TestMethod]
		public void ContactListHas3ContactsToStart()
		{
			//Arrange
			//Assert
			Assert.AreEqual(3, vm.Contacts.Count);
		}
		[TestMethod]
		public void AddCommand_AddsANewContactCard()
		{
			//Arrange

			//Act
			var startingCount = vm.Contacts.Count;
			vm.AddCommand.Execute(null);

			//Assert
			Assert.AreEqual(startingCount + 1, vm.Contacts.Count);
		}

		[TestMethod]
		public void SelectedCardIsSetToNewlyAddedCard()
		{
			vm.AddCommand.Execute(null);


			Assert.AreEqual(vm.SelectedCard, vm.Contacts.Last());

		}
	}
}
