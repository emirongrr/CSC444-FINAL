using StockProductTracking.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StockProductTracking.MVVM.ViewModel
{
    internal abstract class CategoryViewModelBase : ObservableObject , IDataErrorInfo
    {
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                if (columnName == "CategoryTitle")
                {
                    if (string.IsNullOrEmpty(this.CategoryTitle))
                        result = "Kategori ismi boş olamaz";

                    else if (this.CategoryTitle.Length < 3)
                        result = "Minimum 3 karakter boyutunda olmalıdır.";

                    else if (!Regex.IsMatch(this.CategoryTitle, @"^[a-zA-Z]+$"))
                        result = "Sadece harf kabul edilir. [A-z,a-z]";

                }

                return result;
            }
        }
    }

}

