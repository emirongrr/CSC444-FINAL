using StockProductTracking.Core;
using System;
using System.Xml.Linq;

namespace StockProductTracking.MVVM.Model
{
    public class Category : ModelObject
    {
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public DateTime created_at { get; set; }
        public string created_who { get; set; }
        public  override string Dump()
        {
            string dump = string.Empty;

            dump += Environment.NewLine + "ID : " + CategoryId.ToString() + Environment.NewLine;
            dump += Environment.NewLine + "Kategori İsmi : " + CategoryTitle + Environment.NewLine;
            dump += Environment.NewLine + "Oluşturma Zamanı : " + created_at + Environment.NewLine;
            dump += Environment.NewLine + "Oluşturan : " + created_who + Environment.NewLine;

            return dump;
        }
    }
}
