using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using StockProductTracking.Utils;
using System.Text.RegularExpressions;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class ForgotPasswordEmailViewModel : ObservableObject
    {
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
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
                
            }
        }
        public ICommand RequestCodeCommand { get; set; }
        private LoginViewModel loginViewModel { get; set; }
        public ICommand NavigateLoginPageViewCommand { get; set; }
        public ForgotPasswordEmailViewModel(LoginViewModel loginViewModel)
        {
            NavigateLoginPageViewCommand = new RelayCommand(o =>
            {
                loginViewModel.ResetLoginPage();
            });
            RequestCodeCommand = new RelayCommand(ExecuteRequestCodeCommand, CanExecuteRequestCodeCommand);
            this.loginViewModel = loginViewModel;
        }

        private void ExecuteRequestCodeCommand(object o)
        {
            loginViewModel.CurrentView = new GetNewPasswordViewModel(Email, loginViewModel);
        }

        private bool CanExecuteRequestCodeCommand(object o)
        {
            if (String.IsNullOrEmpty(this.Email))
                return false;
            if(!Regex.IsMatch(this.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                ErrorMessage = "Lütfen geçerli bir e-mail giriniz.";
                return false;
            }
            if(!new Connect().GetEmployeeEmail().Contains(Email))
            {
                ErrorMessage = "Yazdığınız e-mail herhangi bir hesapla uyuşmuyor.";
                return false;
            }
            ErrorMessage = String.Empty;
            return true;
        }
    }
}
