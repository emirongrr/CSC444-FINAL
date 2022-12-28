using StockProductTracking.Core;
using System;

namespace StockProductTracking.MVVM.Model
{
    public class Customer : ModelObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string GetFullName => $"{Id} - {Name} {LastName}";
        public DateTime created_at { get; set; }
        public string created_who { get; set; }

        public override string Dump()
        {
            string dump = string.Empty;

            dump += "ID : " + Id.ToString() + Environment.NewLine;
            dump += Environment.NewLine + "Isim : " + Name + Environment.NewLine;
            dump += Environment.NewLine + "Soyad : "+ LastName + Environment.NewLine;
            dump += Environment.NewLine + "Adres : " + Address + Environment.NewLine;
            dump += Environment.NewLine + "Telefon No : " + Phone + Environment.NewLine;
            dump += Environment.NewLine + "Oluşturma Zamanı : " + created_at + Environment.NewLine;
            dump += Environment.NewLine + "Oluşturan Kişi : " + created_who;

            return dump;
        }
    }
}
