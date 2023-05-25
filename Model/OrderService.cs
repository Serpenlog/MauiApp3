namespace MauiApp3
{
    public interface IOrderService
    {
        Order CurrentOrder { get; set; }
    }
    public class OrderService : IOrderService
    {
        public Order CurrentOrder { get; set; }
    }
}