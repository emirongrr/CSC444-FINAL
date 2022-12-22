using System;

namespace StockProductTracking.MVVM.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string GetFullName => $"{Id} - {Name} {LastName}";
        public DateTime created_at { get; set; }
        public string created_who { get; set; }
    }
}
