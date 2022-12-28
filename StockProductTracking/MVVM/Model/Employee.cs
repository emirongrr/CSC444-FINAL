using StockProductTracking.Core;
using System;
using System.Linq;

namespace StockProductTracking.MVVM.Model
{
    internal class Employee : ModelObject
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime created_at { get; set; }
        public string created_who { get; set; }

        public override string Dump()
        {
            string dump = string.Empty;

            dump += "ID : " + Id.ToString() + Environment.NewLine;
            dump += Environment.NewLine + "Isim : " + FirstName + Environment.NewLine;
            dump += Environment.NewLine + "Soyad : " + LastName + Environment.NewLine;
            dump += Environment.NewLine + "Kullanıcı Adı : " + Username + Environment.NewLine;
            dump += Environment.NewLine + "E-mail : " + Email + Environment.NewLine;
            dump += Environment.NewLine + "Admin : " + (IsAdmin ? "Evet" : "Hayır") + Environment.NewLine;
            dump += Environment.NewLine + "Oluşturma Zamanı : " + created_at + Environment.NewLine;
            dump += Environment.NewLine + "Oluşturan Kişi : " + created_who;
            return dump;
        }
    }
    

}
