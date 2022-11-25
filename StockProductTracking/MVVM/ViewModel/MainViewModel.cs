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


        public AcceptedOrderPageViewModel AcceptedOrderPageVM { get; set; }
        public UpdateProductPageViewModel UpdateProductPageVM { get; set; }
        public UpdateCustomerPageViewModel UpdateCustomerPageVM { get; set; }
        public UpdateCategoryPageViewModel UpdateCategoryPageVM { get; set; }
        public AddCustomerPageViewModel AddCustomerPageVM { get; set; }
        public AddProductPageViewModel AddProductPageVM { get; set; }
        public AddCategoryPageViewModel AddCategoryPageVM { get; set; }
        public AddOrderPageViewModel AddOrderPageVM { get; set; }
        public DashboardViewModel DashboardVM { get; set; }
        public ProductsViewModel ProductsVM { get; set; }
        public OrdersViewModel OrderVM { get; set; }
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
            DashboardVM = new DashboardViewModel(this);
            ProductsVM = new ProductsViewModel(this);
            OrderVM = new OrdersViewModel(this);
            CategoryVM = new CategoryViewModel(this);
            CustomersVM = new CustomersViewModel(this);
            AddCustomerPageVM = new AddCustomerPageViewModel(this);
            UpdateCustomerPageVM = new UpdateCustomerPageViewModel(this);
            AddCategoryPageVM = new AddCategoryPageViewModel(this);
            UpdateCategoryPageVM = new UpdateCategoryPageViewModel(this);
            AddProductPageVM = new AddProductPageViewModel(this);
            UpdateProductPageVM = new UpdateProductPageViewModel(this);
            AddOrderPageVM = new AddOrderPageViewModel(this);
            AcceptedOrderPageVM = new AcceptedOrderPageViewModel(this);

            currentView = DashboardVM;

            DashboardViewCommand = new RelayCommand(o =>
            {
                CurrentView = DashboardVM;
                DashboardVM.UpdateDashboard();
            });

            ProductViewCommand = new RelayCommand(o =>
            {
                CurrentView = ProductsVM;
                ProductsVM.UpdateProductList();
            });

            CustomerViewCommand = new RelayCommand(o =>
            {
                CurrentView = CustomersVM;
                CustomersVM.UpdateCustomersList();
            });

            OrderViewCommand = new RelayCommand(o =>
            {
                CurrentView = OrderVM;
                OrderVM.UpdateOrderList();
            });

            CategoryViewCommand = new RelayCommand(o =>
            {
                CurrentView = CategoryVM;
                CategoryVM.UpdateCategoryList();
            });
        }
    }
}
