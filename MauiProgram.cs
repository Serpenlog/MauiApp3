using Microsoft.Extensions.Logging;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using System.Threading.Tasks;
using MauiApp3;

namespace MauiApp3
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddSingleton<IOrderService, OrderService>();
            builder.Services.AddSingleton<OrderPage>();
            builder.Services.AddSingleton<OrderService>();
            builder.Services.AddSingleton<OrderDatabase>();
            builder.Services.AddSingleton<OrderModifier>();
            builder.Services.AddSingleton<OrderPageViewModel>();
            builder.Services.AddSingleton<Order>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<BaseViewModel>();
            
            

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
