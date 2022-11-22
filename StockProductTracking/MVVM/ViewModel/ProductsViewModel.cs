using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using System.Collections.ObjectModel;
using StockProductTracking.Utils;
using Prism.Commands;
using System.Windows.Input;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class ProductsViewModel : ObservableObject

    {
        public Product SelectedProduct { get; set; }

        public ICommand NavigateAddProductCommand { get; }
        public ICommand NavigateUpdateProductCommand { get; }
        public ICommand DeleteProductCommand { get; }

   

        private ObservableCollection<Product> products;
        public ObservableCollection<Product> ProductsList
        {
            get => products;
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }

        public void UpdateProductList()
        {
            Connect db = new Connect();
            ProductsList = db.GetProducts();

        }

        public ProductsViewModel(MainViewModel mainViewModel)
        {
            ProductsList = new ObservableCollection<Product>();
            Connect db = new Connect();
            ProductsList = db.GetProducts();


            DeleteProductCommand = new DelegateCommand<Product>(o =>
            {
                db.DeleteProduct(o.ProductId.ToString());
                _ = ProductsList.Remove(o);
            });


            NavigateAddProductCommand = new RelayCommand(o =>
            {
                mainViewModel.CurrentView = new AddProductPageViewModel(mainViewModel);

            });


            NavigateUpdateProductCommand = new DelegateCommand<Product>(o =>
            {
                UpdateProductPageViewModel updateProductPageViewModel = new UpdateProductPageViewModel(mainViewModel)
                {
                    ProductId = o.ProductId,
                    CategoryID = o.CategoryId,
                    ProductTitle = o.ProductTitle,
                    ProductBrand = o.ProductBrand,
                    ProductPrice = o.ProductPrice,
                    ProductRealPrice = o.ProductRealPrice,
                    ProductStock = o.ProductStock
                };

                mainViewModel.CurrentView = updateProductPageViewModel;
            });
        }
    }
}
