using StockProductTracking.Core;
using StockProductTracking.Utils;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace StockProductTracking.MVVM.ViewModel
{
    internal class EmployeeViewModelBase : ObservableObject, IDataErrorInfo
    {
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeUsername { get; set; }
        public string EmployeePassword { get; set; }
        public string EmployeePasswordAgain { get; set; }
        public string EmployeeEmail { get; set; }
        public bool EmployeeIsAdmin { get; set; }

        public string CheckEMail;
        public string CheckUsername { get; set; }

        Connect db = new Connect();
        

        private string _PassworderrorMessage;
        public string PasswordErrorMessage
        {
            get
            {
                return _PassworderrorMessage;
            }
            set
            {
                _PassworderrorMessage = value;
                OnPropertyChanged(nameof(PasswordErrorMessage));
            }
        }

        private bool _IsEnable = false;
        public bool IsEnable 
        {
            get
            {
                return _IsEnable;
            }

            set
            {
                _IsEnable = value;
                OnPropertyChanged(nameof(IsEnable));
            }
        }
        public string Error
        {
            get { return null; }
        }
        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                
                if (columnName == "EmployeeFirstName")
                {
                    if (string.IsNullOrEmpty(this.EmployeeFirstName))
                        result = "Ad boş olamaz";

                    else if (this.EmployeeFirstName.Length < 3)
                        result = "Minimum 3 karakter boyutunda olmalıdır.";

                    else if (!Regex.IsMatch(this.EmployeeFirstName, @"^[a-zA-Z]+$"))
                        result = "Sadece harf kabul edilir. [A-z,a-z]";

                }
                if (columnName == "EmployeeLastName")
                {
                    if (string.IsNullOrEmpty(this.EmployeeLastName))
                        result = "Soyad boş olamaz";

                    else if (this.EmployeeLastName.Length < 2)
                        result = "Minimum 2 karakter boyutunda olmalıdır.";

                    else if (!Regex.IsMatch(this.EmployeeLastName, @"^[a-zA-Z]+$"))
                        result = "Sadece harf kabul edilir. [A-z,a-z]";

                }
                if (columnName == "EmployeeUsername")
                {

                    if (string.IsNullOrEmpty(this.EmployeeUsername))
                        result = "Kullanıcı Adı boş olamaz";

                    else if (db.GetEmployeeUsername().Contains(this.EmployeeUsername))
                        if (this.EmployeeUsername != CheckUsername)
                            result = "Bu kullanıcı adı zaten var.";

                    else if (this.EmployeeUsername.Length < 3)
                        result = "Minimum 3 karakter boyutunda olmalıdır.";

                }
                if (columnName == "EmployeeEmail")
                {
                    if (string.IsNullOrEmpty(this.EmployeeEmail))
                        result = "Email boş olamaz";
                    else if (db.GetEmployeeEmail().Contains(this.EmployeeEmail))
                        if (this.EmployeeEmail != CheckEMail)
                            result = "Bu mail zaten var.";
                    if (!Regex.IsMatch(this.EmployeeEmail, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                        result = "Uygun mail giriniz. (example@mail.com)";
                }
                if (columnName == "EmployeePassword")
                {                   
                    if (!(EmployeePassword == EmployeePasswordAgain))
                    {
                        PasswordErrorMessage = "Şifreler Eşleşmiyor";
                        IsEnable = false;
                    }
                    else
                    {
                        if (!(string.IsNullOrEmpty(this.EmployeePassword)))
                        {
                            PasswordErrorMessage = " ";
                            IsEnable = true;
                        }
                        else IsEnable = false;
                    }
                }
                if (columnName == "EmployeePasswordAgain")
                {
                    if (!(EmployeePassword == EmployeePasswordAgain))
                    {
                        PasswordErrorMessage = "Şifreler Eşleşmiyor";
                        IsEnable = false;
                    }
                    else
                    {
                        if (!(string.IsNullOrEmpty(this.EmployeePassword)))
                        {
                            PasswordErrorMessage = " ";
                            IsEnable = true;
                        }
                        else IsEnable = false;
                    }
                }
                return result;
            }
        }
    }
}