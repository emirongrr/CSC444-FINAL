using System;

namespace StockProductTracking.MVVM.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public DateTime created_at { get; set; }
        public string created_who { get; set; }

    }
}
