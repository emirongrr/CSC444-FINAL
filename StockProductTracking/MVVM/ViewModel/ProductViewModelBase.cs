using StockProductTracking.Core;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace StockProductTracking.MVVM.ViewModel
{
    internal abstract class ProductViewModelBase : ObservableObject, IDataErrorInfo
    {
        public int ProductId { get; set; }
        public int CategoryID { get; set; }
        public string ProductTitle { get; set; }
        public string ProductBrand { get; set; }
        public string ProductPrice { get; set; }
        public string ProductRealPrice { get; set; }
        public int ProductStock { get; set; }

        private string _PriceErrorMessage;
        public string PriceErrorMessage
        {
            get
            {
                return _PriceErrorMessage;
            }

            set
            {
                _PriceErrorMessage = value;
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                if (columnName == "ProductTitle")
                {
                    if (string.IsNullOrEmpty(this.ProductTitle))
                        result = "Kategori ismi boş olamaz";

                    else if (this.ProductTitle.Length < 3)
                        result = "Minimum 3 karakter boyutunda olmalıdır.";

                }

                if (columnName == "ProductPrice")
                {
                    if (string.IsNullOrEmpty(this.ProductPrice) || !Decimal.TryParse(this.ProductPrice, out _) || Regex.IsMatch(this.ProductPrice, @"^\d + (,?)(\d{ 1,2})?$"))
                    {
                        PriceErrorMessage = "Hatalı fiyat girişi";
                        IsEnable = false;
                    }
                    else
                    {
                        if (Convert.ToDecimal(ProductPrice) < Convert.ToDecimal(ProductRealPrice))
                        {
                            PriceErrorMessage = "Satış fiyatı alış fiyatından düşük olamaz";
                            IsEnable = false;
                        }
                        else
                            PriceErrorMessage = " ";
                        IsEnable = true;
                    }
                }
                if (columnName == "ProductRealPrice")
                {
                    if (string.IsNullOrEmpty(this.ProductRealPrice) || !Decimal.TryParse(this.ProductRealPrice, out _) || Regex.IsMatch(this.ProductRealPrice, @"^\d + (,?)(\d{ 1,2})?$"))
                    {
                        PriceErrorMessage = "Hatalı fiyat girişi";
                        IsEnable = false;
                    }
                    else 
                    {
                        if (Convert.ToDecimal(ProductPrice) < Convert.ToDecimal(ProductRealPrice))
                        {
                            PriceErrorMessage = "Satış fiyatı alış fiyatından düşük olamaz";
                            IsEnable = false;
                        }
                        else
                            PriceErrorMessage = " ";
                            IsEnable=true;
                    }
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
