﻿using SQLite;
namespace MauiApp3.Model
{
    public class OrderModifier
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int OrderID { get; set; }

        public int ModifierID { get; set; }
    }
}
