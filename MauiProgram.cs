using Microsoft.Extensions.Logging;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using System.Threading.Tasks;
using MauiApp3.Service;

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

#if DEBUG
            builder.Logging.AddDebug();
#endif
            Task.WhenAll(OrderDatabase.Instance.Start()); // error, 27

            return builder.Build();
        }
    }
}
