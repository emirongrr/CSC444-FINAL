using StockProductTracking.Core;
using StockProductTracking.Utils;
using System.Windows.Input;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class UpdateProductPageViewModel : ProductViewModelBase
    {
        public ICommand UpdateProductCommand { get; }

        public UpdateProductPageViewModel(MainViewModel mainViewModel)
        {
            UpdateProductCommand = new RelayCommand(o =>
            {
                Connect db = new Connect();
                db.UpdateProduct(ProductId,CategoryID,ProductTitle,ProductStock,ProductPrice,ProductRealPrice,ProductBrand);
                mainViewModel.ProductsVM.UpdateProductList();

            });
        }
    }
}
