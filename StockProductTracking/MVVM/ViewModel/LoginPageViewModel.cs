using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using StockProductTracking.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using StockProductTracking.MVVM.View;

namespace StockProductTracking.MVVM.ViewModel
{
    class LoginPageViewModel : ObservableObject
    {
        public ICommand NavigateForgotPasswordEmail { get; set; }
        private LoginViewModel loginViewModel;
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

        public LoginPageViewModel(LoginViewModel loginViewModel)
        {
            LogInCommand = new RelayCommand(ExecuteLoginComamnd, CanExecuteLoginCommand);
            this.loginViewModel = loginViewModel;

            NavigateForgotPasswordEmail = new RelayCommand(o =>
            {
                loginViewModel.SetViewToForgotPassword();
            });
        }
        public void ExecuteLoginComamnd(object o)
        {
            Employee currentUser = new Connect().LogIn(new NetworkCredential(Username, SHA256Helper.ComputeSha256Hash(Password)));
            if (currentUser == null)
            {
                //invalid credentials
                ErrorMessage = "Geçersiz kullanıcı adı ya da şifre";
                
            }
            else
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                ErrorMessage = " ";
                WindowService windowService = new WindowService();
                windowService.ShowWindow<MainWindow>();
                windowService.CloseWindow<LoginView>();
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
