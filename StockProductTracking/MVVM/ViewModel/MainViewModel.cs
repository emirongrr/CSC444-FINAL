using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using StockProductTracking.MVVM.View;
using StockProductTracking.Utils;
using System.Threading;
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
        public ICommand EmployeeViewCommand { get; set; }
        public ICommand LogOffCommand { get; set; }

        public AcceptedOrderPageViewModel AcceptedOrderPageVM { get; set; }
        public UpdateProductPageViewModel UpdateProductPageVM { get; set; }
        public UpdateEmployeePageViewModel UpdateEmployeePageVM { get; set; }
        public UpdateCustomerPageViewModel UpdateCustomerPageVM { get; set; }
        public UpdateCategoryPageViewModel UpdateCategoryPageVM { get; set; }
        public AddCustomerPageViewModel AddCustomerPageVM { get; set; }
        public AddProductPageViewModel AddProductPageVM { get; set; }
        public AddEmployeePageViewModel AddEmployeePageVM { get; set; }
        public AddCategoryPageViewModel AddCategoryPageVM { get; set; }
        public AddOrderPageViewModel AddOrderPageVM { get; set; }
        public DashboardViewModel DashboardVM { get; set; }
        public ProductsViewModel ProductsVM { get; set; }
        public OrdersViewModel OrderVM { get; set; }
        public EmployeeViewModel EmployeeVM { get; set; }
        public CategoryViewModel CategoryVM { get; set; }
        public CustomersViewModel CustomersVM { get; set; }


        private string _IsVisibleRadioButton = "Hidden";
        public string IsVisibleRadioButton 
        {
            get => _IsVisibleRadioButton;
            set
            {
                _IsVisibleRadioButton = value;
                OnPropertyChanged(nameof(IsVisibleRadioButton));
            }
        }

        private Employee currentUser;
        public Employee CurrentUser
        {
            get =>  currentUser;
            set
            {
                currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }



        private object currentView;
        public object CurrentView
        {
            get => currentView;
            set
            {
                currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public MainViewModel()
        {
            DashboardVM = new DashboardViewModel(this);
            ProductsVM = new ProductsViewModel(this);
            OrderVM = new OrdersViewModel(this);
            CategoryVM = new CategoryViewModel(this);
            CustomersVM = new CustomersViewModel(this);
            EmployeeVM = new EmployeeViewModel(this);

            AddCustomerPageVM = new AddCustomerPageViewModel(this);
            UpdateCustomerPageVM = new UpdateCustomerPageViewModel(this);

            AddCategoryPageVM = new AddCategoryPageViewModel(this);
            UpdateCategoryPageVM = new UpdateCategoryPageViewModel(this);

            AddProductPageVM = new AddProductPageViewModel(this);
            UpdateProductPageVM = new UpdateProductPageViewModel(this);

            AddOrderPageVM = new AddOrderPageViewModel(this);
            AcceptedOrderPageVM = new AcceptedOrderPageViewModel(this);

            AddEmployeePageVM = new AddEmployeePageViewModel(this);
            UpdateEmployeePageVM = new UpdateEmployeePageViewModel(this);


            LoadCurrentUserData();
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

            EmployeeViewCommand = new RelayCommand(o =>
            {
                CurrentView = EmployeeVM;
                EmployeeVM.UpdateEmployeeList();
            });
            LogOffCommand = new RelayCommand(o =>
            {
                WindowService windowService = new WindowService();
                windowService.ShowWindow<LoginView>();
                windowService.CloseWindow<MainWindow>();
            });
        }

        private void LoadCurrentUserData()
        {
            Connect connect = new Connect();
            CurrentUser = new Employee();

            var user = connect.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUser.Username = user.Username;
                CurrentUser.IsAdmin = user.IsAdmin;
                if(CurrentUser.IsAdmin !=  false)
                {
                    IsVisibleRadioButton = "Visible";
                }
                   
            }
            else
            {
                CurrentUser.Username = "Geçersiz kullanýcý";
            }
        }
    }
}
