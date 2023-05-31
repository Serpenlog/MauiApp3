using MauiApp3;
using SQLite;
using System.Collections.Generic;

namespace MauiApp3
{
    public class Order
    {
        [PrimaryKey, AutoIncrement]
        public string MainFoodItem { get; set; }
        public List<string> Modifiers { get; set; }

        public string ModifiersAsString => Modifiers != null ? string.Join(", ", Modifiers) : string.Empty;
        public int ID { get; set; }        
    }
}
