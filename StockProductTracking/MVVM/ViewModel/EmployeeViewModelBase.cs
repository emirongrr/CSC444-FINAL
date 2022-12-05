using StockProductTracking.Core;
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

                    else if (this.EmployeeLastName.Length < 3)
                        result = "Minimum 3 karakter boyutunda olmalıdır.";

                    else if (!Regex.IsMatch(this.EmployeeLastName, @"^[a-zA-Z]+$"))
                        result = "Sadece harf kabul edilir. [A-z,a-z]";

                }
                if (columnName == "EmployeeUsername")
                {
                    if (string.IsNullOrEmpty(this.EmployeeUsername))
                        result = "Kullanıcı Adı boş olamaz";

                    else if (this.EmployeeUsername.Length < 3)
                        result = "Minimum 3 karakter boyutunda olmalıdır.";

                }
                if (columnName == "EmployeeEmail")
                {
                    if (string.IsNullOrEmpty(this.EmployeeEmail))
                        result = "Email boş olamaz";
                    else if (!Regex.IsMatch(this.EmployeeEmail, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                        result = "Uygun mail giriniz. (example@mail.com)";
                   
                }
                if (columnName == "EmployeePassword")
                {
                    if (string.IsNullOrEmpty(this.EmployeePassword))
                        result = "Şifre boş olamaz";
                    else if (!(EmployeePassword == EmployeePasswordAgain))
                        result = "BOŞBOŞBOŞBOŞBOŞB";

                }
                if (columnName == "EmployeePasswordAgain")
                {
                    if (string.IsNullOrEmpty(this.EmployeePasswordAgain))
                        result = "Şifre boş olamaz";
                    else if (!(EmployeePassword == EmployeePasswordAgain))
                        result = "BOŞBOŞBOŞBOŞBOŞB";

                }


                return result;
            }
        }

    } 
}
