using StockProductTracking.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProductTracking.MVVM.Model
{
    public class Order : ModelObject
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string OrderCategoryTitle { get; set; }
        public string OrderProductTitle { get; set; }
        public decimal OrderProductPrice { get; set; }
        public int OrderProductCount { get; set; }
        public bool OrderStatus { get; set; }
        public decimal TotalOrderPrice
        {
            get { return OrderProductPrice * OrderProductCount; }
        }

        public override string Dump()
        {
            string dump = string.Empty;

            dump += "Sipariş ID : " + OrderId.ToString() + Environment.NewLine;
            dump += Environment.NewLine + "Müşteri ID : " + CustomerId.ToString() + Environment.NewLine;
            dump += Environment.NewLine + "Ürün Adı : " + OrderProductTitle + Environment.NewLine;
            dump += Environment.NewLine + "Ürün Fiyatı : " + OrderProductPrice.ToString() + Environment.NewLine;
            dump += Environment.NewLine + "Sipariş Edilen Ürün Sayısı : " + OrderProductCount.ToString() + Environment.NewLine;
            dump += Environment.NewLine + "Sipariş Toplam Ücreti : " + TotalOrderPrice.ToString() + Environment.NewLine;
            dump += Environment.NewLine + "Sipariş Durumu : " + (OrderStatus ? "Onaylandı" : "Onaylanmadı");
            return dump;
        }
    }
}
