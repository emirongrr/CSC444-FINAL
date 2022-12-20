using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using System.Collections.ObjectModel;
using StockProductTracking.Utils;
using Prism.Commands;
using System.Windows.Input;
using System.Windows.Forms;
using System;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class CategoryViewModel : ObservableObject
    {
        public Category SelectedCategory { get; set; }

        public ICommand NavigateAddCategoryCommand { get; }
        public ICommand NavigateUpdateCategoryCommand { get; }
        public ICommand DeleteCategoryCommand { get; }

        private ObservableCollection<Category> category;
        public ObservableCollection<Category> CategoryList
        {
            get => category;
            set
            {
                category = value;
                OnPropertyChanged();
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public void UpdateCategoryList()
        {
            Connect db = new Connect();
            CategoryList = db.GetCategory();

        }

        public CategoryViewModel(MainViewModel mainViewModel)
        {
            CategoryList = new ObservableCollection<Category>();
            Connect db = new Connect();
            CategoryList = db.GetCategory();

            DeleteCategoryCommand = new DelegateCommand<Category>(o =>
            {
                try
                {
                    db.DeleteCategory(o.CategoryId.ToString());
                    _ = CategoryList.Remove(o);
                    Message = " ";
                }
                catch (Exception e)
                {
                    Message = "Ürünlerde ekli olan kategori silinemez";
                }
            });


            NavigateAddCategoryCommand = new RelayCommand(o =>
            {
                mainViewModel.CurrentView = new AddCategoryPageViewModel(mainViewModel);

            });


            NavigateUpdateCategoryCommand = new DelegateCommand<Category>(o =>
            {
                UpdateCategoryPageViewModel updateCategoryPageViewModel = new UpdateCategoryPageViewModel(mainViewModel)
                {
                    CategoryId = o.CategoryId,
                    CategoryTitle = o.CategoryTitle,

                };

                mainViewModel.CurrentView = updateCategoryPageViewModel;
            });


        }
    }
}