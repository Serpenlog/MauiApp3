using SQLite;
using System.Collections.Generic;

namespace MauiApp3
{
    public class Order
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string MainFoodItem { get; set; }
    }
}
