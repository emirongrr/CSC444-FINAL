using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using StockProductTracking.Core;

namespace StockProductTracking.MVVM.ViewModel
{
     class LoginViewModel : ObservableObject
    {
        private string _username;
        private SecureString _password;
        private bool _isVisibleTrue = true;

        public string Username 
        
        { 
            get { return _username; }

            set 
            { 
                _username = value;
                OnPropertyChanged(nameof(Username));
            } 

        }
        public SecureString Password 
        {
            get { return _password; }
           
            set 
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                
            }
        }
        public bool IsVisibleTrue 
        {
            get { return _isVisibleTrue;}
            set 
            { 
                _isVisibleTrue = value;
                OnPropertyChanged(nameof(IsVisibleTrue));
                
            }
        }
    }
}
