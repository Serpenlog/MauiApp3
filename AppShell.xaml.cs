namespace MauiApp3;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute("assembly:namespace/OrderPage", typeof(OrderPage));

        Routing.RegisterRoute(nameof(SQLQueryPage), typeof(SQLQueryPage));
    }
}