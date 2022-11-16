using StockProductTracking.Core;
using StockProductTracking.Utils;
using System.Windows.Input;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class UpdateCategoryPageViewModel : CategoryViewModelBase
    {
        public ICommand UpdateCategoryCommand { get; }

        public UpdateCategoryPageViewModel(MainViewModel mainViewModel)
        {
            UpdateCategoryCommand = new RelayCommand(o =>
            {
                Connect db = new Connect();
                db.UpdateCategory(CategoryId, CategoryTitle);
                mainViewModel.CategoryVM.UpdateCategoryList();

            });
        }
    }
}
