using StockProductTracking.Core;
using StockProductTracking.Utils;
using System.Windows.Input;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class AddCategoryPageViewModel : CategoryViewModelBase
    {
        public ICommand AddCategoryCommand { get; }
        public AddCategoryPageViewModel(MainViewModel mainViewModel)
        {
            AddCategoryCommand = new RelayCommand(o =>
            {
                Connect db = new Connect();
                db.AddCategory(CategoryTitle,mainViewModel.CurrentUser.Username);
                mainViewModel.CategoryVM.UpdateCategoryList();
                mainViewModel.CurrentView = mainViewModel.CategoryVM;
            });
        }
    }
}
