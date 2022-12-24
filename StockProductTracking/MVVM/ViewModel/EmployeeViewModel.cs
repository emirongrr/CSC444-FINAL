using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using System.Collections.ObjectModel;
using StockProductTracking.Utils;
using Prism.Commands;
using System.Windows.Input;
using System.Windows.Data;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class EmployeeViewModel : ObservableViewDataObject
    {
        public Employee SelectedEmployee { get; set; }
        public ICommand NavigateAddEmployeeCommand { get; }
        public ICommand NavigateUpdateEmployeeCommand { get; }
        public ICommand DeleteEmployeeCommand { get; }

        private ObservableCollection<Employee> employees;
        public ObservableCollection<Employee> EmployeeList
        {
            get => employees;
            set
            {
                employees = value;
                OnPropertyChanged(nameof(EmployeeList));
            }
        }

        public void UpdateEmployeeList()
        {
            Connect db = new Connect();
            EmployeeList = db.GetEmployee();
            CollectionView = CollectionViewSource.GetDefaultView(EmployeeList);
        }
        public override bool SearchFilter(object o)
        {
            Employee employee = o as Employee;
            if (employee == null || SearchKey == null)
                return false;
            if(SearchKey.ToLower() == "admin" && employee.IsAdmin)
                return true;
            return SearchKey.Trim() == string.Empty || employee.Username.ToLower().Contains(SearchKey.Trim().ToLower()) || employee.Email.ToLower().Contains(SearchKey.Trim().ToLower()) || employee.FirstName.ToLower().Contains(SearchKey.Trim().ToLower()) || employee.LastName.ToLower().Contains(SearchKey.Trim().ToLower());
        }
        public EmployeeViewModel(MainViewModel mainViewModel)
        {
            EmployeeList = new ObservableCollection<Employee>();
            Connect db = new Connect();
            EmployeeList = db.GetEmployee();
            CollectionView = CollectionViewSource.GetDefaultView(EmployeeList);

            DeleteEmployeeCommand = new DelegateCommand<Employee>(o =>
            {
                db.DeleteEmployee(o.Id.ToString());
                _ = EmployeeList.Remove(o);
            });

            NavigateAddEmployeeCommand = new RelayCommand(o =>
            {
                mainViewModel.CurrentView = new AddEmployeePageViewModel(mainViewModel);

            });

            NavigateUpdateEmployeeCommand = new DelegateCommand<Employee>(o =>
            {
                UpdateEmployeePageViewModel updateEmployeePageViewModel = new UpdateEmployeePageViewModel(mainViewModel)
                {
                    EmployeeId = o.Id,
                    EmployeeFirstName = o.FirstName,
                    EmployeeLastName = o.LastName,
                    EmployeeUsername = o.Username,
                    EmployeePassword = o.Password,
                    EmployeeEmail = o.Email,
                    CheckUsername = o.Username,
                    CheckEMail = o.Email,
                    EmployeeIsAdmin = o.IsAdmin
                };
                mainViewModel.CurrentView = updateEmployeePageViewModel;
            });
        }
    }
}

