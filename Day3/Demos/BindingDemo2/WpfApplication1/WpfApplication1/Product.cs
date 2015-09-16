using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Windows.Data;
using WpfApplication1.Annotations;

namespace WpfApplication1
{
	//[DebuggerDisplay(Price,"Price")]
	public class Product : INotifyPropertyChanged
	{
		private int _price;
		public string Type { get; set; }

		public int Price
		{
			get { return _price; }
			set
			{
				_price = value;
				OnPropertyChanged();
			}
		}

		public override string ToString()
		{
			return string.Format("{0} {1}", Type, Price);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	public class ProductList : INotifyPropertyChanged
	{
		private string _search;
		public ObservableCollection<Product> Products { get; set; }

		public string Search
		{
			get { return _search; }
			set
			{
				_search = value;

				ICollectionView cv = CollectionViewSource.GetDefaultView(Products);
				cv.Filter = o =>
				{
					var product = (Product)o;
					return product.Type.Contains(Search);
				};
				OnPropertyChanged();

			}
		}

		public ProductList()
		{
			Products = new ObservableCollection<Product>
			{
				new Product
				{
					Type = "Mouse",
					Price = 10
				},
				new Product
				{
					Type = "Keyboard",
					Price = 5
				}
			};
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
