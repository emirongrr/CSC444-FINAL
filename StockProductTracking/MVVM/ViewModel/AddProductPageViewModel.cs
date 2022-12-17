using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using StockProductTracking.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace StockProductTracking.MVVM.ViewModel
{
    internal class AddProductPageViewModel : ProductViewModelBase
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



        public ICommand AddProductCommand { get; }

        public AddProductPageViewModel(MainViewModel mainViewModel)
        {

            Connect connect = new Connect();
            Categories = connect.GetCategory();



            AddProductCommand = new RelayCommand(o =>
            {
                Connect db = new Connect();
                db.AddProduct(CategoryID, ProductTitle, ProductStock, ProductPrice, ProductRealPrice, ProductBrand);
                mainViewModel.ProductsVM.UpdateProductList();
                mainViewModel.CurrentView = mainViewModel.ProductsVM;

            });

        }
    }
}
