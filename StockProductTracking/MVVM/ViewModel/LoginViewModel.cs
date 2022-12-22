using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Threading;
using System.Windows.Input;
using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using StockProductTracking.Utils;

namespace StockProductTracking.MVVM.ViewModel
{
    class LoginViewModel : ObservableObject
    {
        private string _username;
        public string Username

        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }

        }

        private SecureString _password;
        public SecureString Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private bool _isViewVisible = true;
        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }
        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public ICommand LogInCommand { get; }

        public LoginViewModel()
        {
            LogInCommand = new RelayCommand(ExecuteLoginComamnd,CanExecuteLoginCommand);
        }
        public void ExecuteLoginComamnd(object o)
        {
            Employee currentUser = new Connect().LogIn(new NetworkCredential(Username,SHA256Helper.ComputeSha256Hash(Password))); 
            
            if (currentUser == null)
            {
                //invalid credentials
                ErrorMessage = "Geçersiz kullanıcı adı ya da şifre";       
            }
            else
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
        }
        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }
    }
}
