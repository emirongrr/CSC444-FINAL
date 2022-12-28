using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using System.Collections.ObjectModel;
using StockProductTracking.Utils;
using Prism.Commands;
using System.Windows.Input;
using System.Windows.Data;
using System;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class ProductsViewModel : ObservableViewDataObject
    {
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
            ProductsList = new ObservableCollection<Product>();
            Connect db = new Connect();
            ProductsList = db.GetProducts();
            CollectionView = CollectionViewSource.GetDefaultView(ProductsList);
        }
        public override bool SearchFilter(object o)
        {
            Product product = o as Product;
            if (product == null || SearchKey == null)
                return false;
            return SearchKey.Trim() == String.Empty || product.ProductBrand.ToLower().Contains(SearchKey.Trim().ToLower()) || product.ProductTitle.ToLower().Contains(SearchKey.Trim().ToLower());
        }
        public ProductsViewModel(MainViewModel mainViewModel)
        {
            ProductsList = new ObservableCollection<Product>();
            Connect db = new Connect();
            ProductsList = db.GetProducts();
            CollectionView = CollectionViewSource.GetDefaultView(ProductsList);

            DeleteProductCommand = new DelegateCommand<Product>(o =>
            {
                new Connect().DeleteProduct(o.ProductId.ToString());
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
