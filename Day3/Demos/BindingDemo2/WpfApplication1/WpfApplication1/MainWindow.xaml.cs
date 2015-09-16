using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		ProductList productsList = new ProductList();
		public MainWindow()
		{
			InitializeComponent();
			DataContext = productsList;
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			//productsList.Products[0].Price = 500;
			productsList.Products.Add(new Product
			{
				Type = "iPad",
				Price = 999999
			});
		}

	
		private void FilterItems(object sender, RoutedEventArgs e)
		{
			ICollectionView cv = CollectionViewSource.GetDefaultView(productsList.Products);
			cv.Filter = o =>
			{
				var product = (Product) o;
				return product.Price < 100;
			};
			cv.SortDescriptions.Add(new SortDescription("Type",ListSortDirection.Ascending));
		}

		private void UnFilterItems(object sender, RoutedEventArgs e)
		{
			ICollectionView cv = CollectionViewSource.GetDefaultView(productsList.Products);
			cv.Filter = null;
			cv.SortDescriptions.Clear();
		}
	}
}
