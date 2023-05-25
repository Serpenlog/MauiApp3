namespace MauiApp3;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(OrderPage), typeof(OrderPage));
        Routing.RegisterRoute(nameof(SQLQueryPage), typeof(SQLQueryPage));
    }
}