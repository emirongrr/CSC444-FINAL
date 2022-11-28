using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Windows.Controls;
using System.Windows.Input;
using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using StockProductTracking.MVVM.View;
using StockProductTracking.Utils;

namespace StockProductTracking.MVVM.ViewModel
{
    class LoginViewModel : ObservableObject
    {
        public LoginView CurrentWindow { get; set; }
        private string _username;
        private bool _isVisibleTrue = true;
        public ICommand LogInCommand { get; }


        public string Username

        {
            get { return _username; }

            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }

        }
        public bool IsVisibleTrue
        {
            get { return _isVisibleTrue; }
            set
            {
                _isVisibleTrue = value;
                OnPropertyChanged(nameof(IsVisibleTrue));

            }
        }
        public void LogIn(object o)
        {
            var passwordBox = o as PasswordBox;
            var password = SHA256Helper.ComputeSha256Hash(passwordBox.Password);
            Employee currentUser = new Connect().LogIn(_username, password);
            
            //AUTO LOGIN FOR DEBUGGING
            if (false)
            {
                currentUser = new Employee()
                {
                    Id = 0,
                    FirstName = "root",
                    LastName = "root",
                    Email = "root@mail.com",
                    Username = "root",
                    IsAdmin = true,
                };
            }
            /////AUTO LOGIN FOR DEBUGGING
            
            if (currentUser == null)
            {
                //invalid credentials
                CurrentWindow.ShowMessageBox("Hatali giris");
            }
            else
            {
                MainViewModel mainDataContext = new MainViewModel()
                {
                    CurrentUser = currentUser
                };
                MainWindow mw = new MainWindow
                {
                    DataContext = mainDataContext
                };
                mw.Show();
                CurrentWindow.Close();
            }
        }
        public LoginViewModel()
        {
            LogInCommand = new RelayCommand(LogIn);
        }
    }
}
