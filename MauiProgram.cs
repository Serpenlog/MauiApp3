using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.Data.SqlClient;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MauiApp3.Connection;

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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<IOrderService, OrderService>();

            var connectionSettings = GetConnectionSettings("MauiApp3.Connection.connection.xml"); // TODO: Replace with actual path
            var connectionString = connectionSettings.GetConnection();

            TestConnectionString(connectionString); // just for debugging

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static ConnectionSettings GetConnectionSettings(string filename) 
        {
            if (!File.Exists(filename)) throw new FileNotFoundException();

            var serializer = new XmlSerializer(typeof(ConnectionSettings));
            using (var stream = File.OpenRead(filename))
            {
                return (ConnectionSettings)serializer.Deserialize(stream); 
            }
        }

        public static void TestConnectionString(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                System.Diagnostics.Debug.WriteLine("Connection string: " + connectionString);
                try
                {
                    connection.Open();
                    System.Diagnostics.Debug.WriteLine($"Connection string: {connectionString}");
                    System.Diagnostics.Debug.WriteLine("Successfully connected to the database.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to connect to the database: " + ex.Message);
                    throw;
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }
    }

}
