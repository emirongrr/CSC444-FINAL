using StockProductTracking.Core;
using StockProductTracking.Utils;
using System.Windows.Input;


namespace StockProductTracking.MVVM.ViewModel
{
    internal class AddProductPageViewModel : ProductViewModelBase
    {
        public ICommand AddProductCommand { get; }

        public AddProductPageViewModel(MainViewModel mainViewModel)
        {

            AddProductCommand = new RelayCommand(o =>
            {
                Connect db = new Connect();
                db.AddProduct(CategoryID,ProductTitle, ProductStock, ProductPrice,ProductRealPrice,ProductBrand);
                mainViewModel.ProductsVM.UpdateProductList();
            });

        }
    }
}
