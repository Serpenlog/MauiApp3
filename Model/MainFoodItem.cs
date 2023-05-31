using SQLite;

namespace MauiApp3
{
    public class MainFoodItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
