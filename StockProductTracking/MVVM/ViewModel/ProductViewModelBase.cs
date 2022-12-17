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
    internal abstract class ProductViewModelBase : ObservableObject, IDataErrorInfo
    {
        public int ProductId { get; set; }
        public int CategoryID { get; set; }
        public string ProductTitle { get; set; }
        public string ProductBrand { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductRealPrice { get; set; }
        public int ProductStock { get; set; }

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                if (columnName == "ProductTitle")
                {
                    if (string.IsNullOrEmpty(this.ProductTitle))
                        result = "Kategori ismi boş olamaz";

                    else if (this.ProductTitle.Length < 3)
                        result = "Minimum 3 karakter boyutunda olmalıdır.";

                }

                if (columnName == "ProductPrice")
                {


                    if (!(this.ProductPrice > this.ProductRealPrice))
                        result = "Satış fiyatı alış fiyatından büyük olmalıdır.";

                    else if (Regex.IsMatch((Convert.ToString(this.ProductPrice)), @"^\d+(\.\d{2})?$"))
                        result = "Sadece rakam kabul edilir. [0-9]";


                }
                if (columnName == "ProductRealPrice")
                {

                    if ((this.ProductPrice < this.ProductRealPrice))
                        result = "Satış fiyatı alış fiyatından büyük olmalıdır.";

                    else if (Regex.IsMatch((Convert.ToString(this.ProductPrice)), @"^\d+(\.\d+)?$"))
                        result = "Sadece rakam kabul edilir. [0-9]";

                }


                if (columnName == "ProductStock")
                {

                    if (!Regex.IsMatch((Convert.ToString(this.ProductStock)), @"^[0-9]+$"))
                        result = "Sadece rakam kabul edilir. [0-9]";

                }

                if (columnName == "ProductBrand")
                {
                    if (string.IsNullOrEmpty(this.ProductBrand))
                        result = "Marka ismi boş olamaz";

                    else if (this.ProductBrand.Length < 3)
                        result = "Minimum 3 karakter boyutunda olmalıdır.";

                }

                return result;
            }
        }

    }
}
