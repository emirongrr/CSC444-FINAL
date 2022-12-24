using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Input;
using StockProductTracking.Core;
using StockProductTracking.MVVM.Model;
using StockProductTracking.Utils;

namespace StockProductTracking.MVVM.ViewModel
{
    class LoginViewModel : ObservableObject
    {
        public LoginPageViewModel LoginPageVM { get; set; }
        public ICommand NavigateLoginPageViewCommand { get; set; }

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

        public LoginViewModel()
        {
            ResetLoginPage();
        }
        public void ResetLoginPage()
        {
            CurrentView = new LoginPageViewModel(this);
        }
        public void SetViewToForgotPassword()
        {
            CurrentView = new ForgotPasswordEmailViewModel(this);
        }

    }
}
