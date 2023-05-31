using MauiApp3;
using SQLite;
using System.Collections.Generic;

namespace MauiApp3
{
    public class Order
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public List<MainFoodItem> MainFoodItems { get; set; }
        public List<Modifier> Modifiers { get; set; }
    }
}
