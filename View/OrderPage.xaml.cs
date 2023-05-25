using Microsoft.Maui.Controls;

namespace MauiApp3
{
    public partial class OrderPage : ContentPage
    {
        private readonly IOrderService _orderService;
        private readonly AppDbContext _dbContext;

        public OrderPage() : this(App.ServiceProvider.GetRequiredService<IOrderService>(), App.ServiceProvider.GetRequiredService<AppDbContext>())
        {
        }

        public OrderPage(IOrderService orderService, AppDbContext dbContext)
        {
            InitializeComponent();

            _orderService = orderService;
            _dbContext = dbContext;
            this.BindingContext = new OrderPageViewModel(_orderService, _dbContext); // line 20
        }

    }
}
