using System.Collections.Generic;
using System.Linq;
using ApprovalTests;
using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WpfAddressBook.Interfaces;
using WpfAddressBook.ViewModels;

namespace ViewModel.Tests
{
	[TestClass]
	[UseReporter(typeof(DiffReporter))]
	public class MainViewModelTests
	{

		private MainViewModel vm;
		private Mock<IDatabase> _mockDatabase;

		[ClassInitialize]
		public static void ClassSetup(TestContext context)
		{
			
		}

		[TestInitialize]
		public void TestSetup()
		{
			_mockDatabase = new Mock<IDatabase>();

			vm = new MainViewModel(_mockDatabase.Object);
		}

		[TestMethod]
		public void OnAddSaveToDatabaseIsCalledWithContactList()
		{
			IEnumerable<ContactViewModel> contacts = null;
			_mockDatabase
				.Setup(x => x.Save(It.IsAny<IEnumerable<ContactViewModel>>()))
				.Callback<IEnumerable<ContactViewModel>>(c => contacts = c);

			vm.AddCommand.Execute(null);

			_mockDatabase.VerifyAll();
			Assert.IsNotNull(contacts);
			Assert.AreNotEqual(0,contacts.Count());
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
			Approvals.Verify(vm.SelectedCard);

		}
	}
}
