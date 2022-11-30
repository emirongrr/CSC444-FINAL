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


                return result;
            }
        }

    } 
}
