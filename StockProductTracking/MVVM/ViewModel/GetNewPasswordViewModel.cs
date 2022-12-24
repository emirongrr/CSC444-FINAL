using StockProductTracking.Core;
using StockProductTracking.Utils;
using System.Windows.Input;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class GetNewPasswordViewModel : ObservableObject
    {
        private string realValidationCode;

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
        private string _validationCode;
        public string ValidationCode 
        { 
            get
            {
                return _validationCode;
            }
            set
            {
                _validationCode = value;
                OnPropertyChanged(nameof(ValidationCode));
            }
        }
        private string _password;
        public string Password
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

        private string _passwordAgain;
        public string PasswordAgain
        {
            get
            {
                return _passwordAgain;
            }
            set
            {
                _passwordAgain = value;
                OnPropertyChanged(nameof(PasswordAgain));
            }
        }
        private string _email;
        private LoginViewModel loginViewModel;
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand NavigateLoginPageViewCommand { get; set; }
        public GetNewPasswordViewModel(string email,LoginViewModel loginViewModel)
        {
            _email = email;
            this.loginViewModel = loginViewModel;
            realValidationCode = "1234";
            NavigateLoginPageViewCommand = new RelayCommand(o =>
            {
                loginViewModel.ResetLoginPage();
            });
            ChangePasswordCommand = new RelayCommand(ExecuteChangePasswordCommand, CanExecuteChangePasswordCommand);
        }
        private void ExecuteChangePasswordCommand(object o)
        
        {
           new Connect().ChangePasswordFromEmail(Password, _email);

            loginViewModel.ResetLoginPage();
        }
        private bool CanExecuteChangePasswordCommand(object o)
        {
            if (string.IsNullOrEmpty(ValidationCode))
            {
                ErrorMessage = "Onay kodu boş olamaz.";
                return false;
            }
            if(ValidationCode != realValidationCode)
            {
                ErrorMessage = "Onay kodu yanlış.";
                return false;
            }
            if(string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(PasswordAgain))
            {
                ErrorMessage = "Şifreler boş olamaz";
                return false;
            }
            if(Password != PasswordAgain)
            {
                ErrorMessage = "Şifreler eşleşmiyor.";
                return false;
            }
            ErrorMessage = "";
            return true;
        }
    }
}
