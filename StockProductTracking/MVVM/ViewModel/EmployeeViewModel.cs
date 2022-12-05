﻿using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using System.Collections.ObjectModel;
using StockProductTracking.Utils;
using Prism.Commands;
using System.Windows.Input;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class EmployeeViewModel : ObservableObject
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
                OnPropertyChanged();
            }
        }

        public void UpdateEmployeeList()
        {
            Connect db = new Connect();
            EmployeeList = db.GetEmployee();

        }

        public EmployeeViewModel(MainViewModel mainViewModel)
        {
            EmployeeList = new ObservableCollection<Employee>();
            Connect db = new Connect();
            EmployeeList = db.GetEmployee();

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
                    EmployeeIsAdmin = o.IsAdmin
                };

                mainViewModel.CurrentView = updateEmployeePageViewModel;
            });


        }
    }

}

