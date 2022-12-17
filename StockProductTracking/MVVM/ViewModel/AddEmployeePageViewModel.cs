using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using StockProductTracking.Utils;
using System.Linq.Expressions;
using System.Net;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class AddEmployeePageViewModel : EmployeeViewModelBase
    {
        public ICommand AddEmployeeCommand { get; }

        public AddEmployeePageViewModel(MainViewModel mainViewModel)
        {
            AddEmployeeCommand = new RelayCommand(o =>
            {
                Connect db = new Connect();
                db.AddEmployee(EmployeeFirstName, EmployeeLastName, EmployeeUsername, EmployeePassword, EmployeeEmail, EmployeeIsAdmin);
                mainViewModel.EmployeeVM.UpdateEmployeeList();
                mainViewModel.CurrentView = mainViewModel.EmployeeVM;
            },
            b =>IsEnable);
        }
    }
}
