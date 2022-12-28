using StockProductTracking.Core;
using System;
using System.IO.Packaging;

namespace StockProductTracking.MVVM.Model
{
    public class Product : ModelObject
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

        public override string Dump()
        {
            string dump = string.Empty;

            dump += "Ürün ID : " + ProductId.ToString() + Environment.NewLine;
            dump += Environment.NewLine + "Ürün Adı : " + ProductTitle + Environment.NewLine;
            dump += Environment.NewLine + "Kategori ID : " + CategoryId.ToString() + Environment.NewLine;
            dump += Environment.NewLine + "Ürün Markası : " + ProductBrand + Environment.NewLine;
            dump += Environment.NewLine + "Ürün Satış Fiyatı : " + ProductPrice.ToString() + Environment.NewLine;
            dump += Environment.NewLine + "Ürün Alış Fiyatı : " + ProductRealPrice.ToString() + Environment.NewLine;
            dump += Environment.NewLine + "Stok Sayısı : " + ProductStock.ToString() + Environment.NewLine;
            dump += Environment.NewLine + "Oluşturma Zamanı : " + created_at + Environment.NewLine;
            dump += Environment.NewLine + "Oluşturan Kişi : " + created_who;
            return dump;
        }
    }
}
