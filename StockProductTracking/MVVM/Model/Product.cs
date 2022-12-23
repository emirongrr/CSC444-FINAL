using System;

namespace StockProductTracking.MVVM.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductBrand { get; set; }
        public string ProductPrice { get; set; } //satış
        public string ProductRealPrice { get; set; } //alış
        public int ProductStock { get; set; }
        public DateTime created_at { get; set; }
        public string created_who { get; set; }
    }
}
