using MauiApp3.Service;
using Microsoft.Maui.Controls;

namespace MauiApp3
{
    public partial class OrderPage : ContentPage
    {
        private readonly IOrderService _orderService;
        private readonly OrderDatabase _orderDatabase;

        public OrderPage() : this(App.ServiceProvider.GetRequiredService<IOrderService>(), App.ServiceProvider.GetRequiredService<OrderDatabase>())
        {
        }

        public OrderPage(IOrderService orderService, OrderDatabase orderDatabase)
        {
            InitializeComponent();

            _orderService = orderService;
            _orderDatabase = orderDatabase;
            this.BindingContext = new OrderPageViewModel(_orderService, _orderDatabase); // line 20
        }

    }
}
