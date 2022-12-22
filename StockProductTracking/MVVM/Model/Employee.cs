using System;

namespace StockProductTracking.MVVM.Model
{
    internal class Employee
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
    }
}
