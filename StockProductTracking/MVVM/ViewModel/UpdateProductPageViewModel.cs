using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using StockProductTracking.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class UpdateProductPageViewModel : ProductViewModelBase
    {
        private ObservableCollection<Category> categories;
        public ObservableCollection<Category> Categories
        {
            get => categories;
            set
            {
                categories = value;
                OnPropertyChanged();
            }
        }

        public ICommand UpdateProductCommand { get; }

        public UpdateProductPageViewModel(MainViewModel mainViewModel)
        {
            Connect connect = new Connect();
            Categories = connect.GetCategory();

            UpdateProductCommand = new RelayCommand(o =>
            {
                Connect db = new Connect();
                db.UpdateProduct(ProductId, CategoryID, ProductTitle, ProductStock, ProductPrice, ProductRealPrice, ProductBrand);
                mainViewModel.ProductsVM.UpdateProductList();

            });
        }
    }
}
