using StockProductTracking.Core;
using System.Windows.Input;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public ICommand DashboardViewCommand { get; set; }
        public ICommand ProductViewCommand { get; set; }
        public ICommand CustomerViewCommand { get; set; }
        public ICommand OrderViewCommand { get; set; }
        public ICommand CategoryViewCommand { get; set; }


        public UpdateProductPageViewModel UpdateProductPageVM { get; set; }
        public UpdateCustomerPageViewModel UpdateCustomerPageVM { get; set; }
        public UpdateCategoryPageViewModel UpdateCategoryPageVM { get; set; }
        public AddCustomerPageViewModel AddCustomerPageVM { get; set; }
        public AddProductPageViewModel AddProductPageVM { get; set; }
        public AddCategoryPageViewModel AddCategoryPageVM { get; set; }
        public DashboardViewModel DashboardVM { get; set; }
        public ProductsViewModel ProductsVM { get; set; }
        public OrderViewModel OrderVM { get; set; }
        public CategoryViewModel CategoryVM { get; set; }
        public CustomersViewModel CustomersVM { get; set; }

        private object currentView;

        public object CurrentView
        {
            get => currentView;
            set
            {
                currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            DashboardVM = new DashboardViewModel();
            ProductsVM = new ProductsViewModel(this);
            OrderVM = new OrderViewModel();
            CategoryVM = new CategoryViewModel(this);
            CustomersVM = new CustomersViewModel(this);
            AddCustomerPageVM = new AddCustomerPageViewModel(this);
            UpdateCustomerPageVM = new UpdateCustomerPageViewModel(this);
            AddCategoryPageVM = new AddCategoryPageViewModel(this);
            UpdateCategoryPageVM = new UpdateCategoryPageViewModel(this);
            AddProductPageVM = new AddProductPageViewModel(this);
            UpdateProductPageVM = new UpdateProductPageViewModel(this);

            currentView = DashboardVM;

            DashboardViewCommand = new RelayCommand(o =>
            {
                CurrentView = DashboardVM;
            });

            ProductViewCommand = new RelayCommand(o =>
            {
                CurrentView = ProductsVM;
            });

            CustomerViewCommand = new RelayCommand(o =>
            {
                CurrentView = CustomersVM;
            });

            OrderViewCommand = new RelayCommand(o =>
            {
                CurrentView = OrderVM;
            });

            CategoryViewCommand = new RelayCommand(o =>
            {
                CurrentView = CategoryVM;
            });
        }
    }
}
