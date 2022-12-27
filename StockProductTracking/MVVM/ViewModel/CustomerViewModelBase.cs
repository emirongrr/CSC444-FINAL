using StockProductTracking.Core;
using StockProductTracking.Utils;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace StockProductTracking.MVVM.ViewModel
{
    internal abstract class CustomerViewModelBase : ObservableObject, IDataErrorInfo
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }

        Connect db = new Connect();

        public string CheckPhone;

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                if (columnName == "CustomerName")
                {
                    if (string.IsNullOrEmpty(this.CustomerName))
                        result = "Ad boþ olamaz";

                    else if (this.CustomerName.Length < 3)
                        result = "Minimum 3 karakter boyutunda olmalýdýr.";

                    else if (!Regex.IsMatch(this.CustomerName, @"^[a-zA-Z]+$"))
                        result = "Sadece harf kabul edilir. [A-z,a-z]";

                }
                else if (columnName == "CustomerLastName")
                {
                    if (string.IsNullOrEmpty(this.CustomerLastName))
                        result = "Soyad boþ olamaz";

                    else if (this.CustomerLastName.Length < 2)
                        result = "Minimum 2 karakter boyutunda olmalýdýr";

                    else if (!Regex.IsMatch(this.CustomerLastName, @"^[a-zA-Zöü]+$"))
                        result = "Sadece harf kabul edilir. [A-z,a-z]";
                }
                else if (columnName == "CustomerPhone")
                {
                    if (string.IsNullOrEmpty(this.CustomerPhone))
                        result = "Telefon numarasý boþ olamaz";

                    else if (!this.CustomerPhone.Trim().StartsWith("0"))
                        result = "Telefon numarasý 0 ile baþlamalýdýr.";

                    else if (this.CustomerPhone.Length != 11)
                        result = "11 karakter uzunluðunda olmalýdýr (0XXXXXXXXXX)";

                    else if (db.GetCustomerPhone().Contains(this.CustomerPhone))
                        if (this.CustomerPhone != CheckPhone)
                            result = "Bu telefon zaten var.";

                        else if (!Regex.IsMatch(this.CustomerPhone, @"^[0-9]+$"))
                        result = "Sadece rakam kabul edilir.";

                }
                else if (columnName == "CustomerAddress")
                {
                    if (string.IsNullOrEmpty(this.CustomerAddress))
                        result = "Adres boþ olamaz";

                }

                return result;
            }
        }
    }
}
