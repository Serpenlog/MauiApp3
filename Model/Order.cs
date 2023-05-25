namespace MauiApp3
{
    public class Order
    {
        public string MainFoodItem { get; set; }
        public List<string> Modifiers { get; set; }

        public string ModifiersAsString => Modifiers != null ? string.Join(", ", Modifiers) : string.Empty;
    }
}