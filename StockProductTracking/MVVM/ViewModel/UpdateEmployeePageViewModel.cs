using StockProductTracking.Core;
using StockProductTracking.Utils;
using System.Windows.Input;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class UpdateEmployeePageViewModel : EmployeeViewModelBase
    {
        public ICommand UpdateEmployeeCommand { get; }

        public UpdateEmployeePageViewModel(MainViewModel mainViewModel)
        {
            UpdateEmployeeCommand = new RelayCommand(o =>
            {
                Connect db = new Connect();

                db.UpdateEmployee(EmployeeId, EmployeeFirstName, EmployeeLastName,EmployeeUsername,EmployeePassword, EmployeeEmail, EmployeeIsAdmin);
                mainViewModel.EmployeeVM.UpdateEmployeeList();
                mainViewModel.CurrentView = mainViewModel.EmployeeVM;

            },
            canExecute => IsEnable);
        }
    }
}
