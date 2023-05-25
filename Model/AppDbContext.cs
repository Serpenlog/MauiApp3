using Microsoft.EntityFrameworkCore;
using MauiApp3.Connection;

namespace MauiApp3
{
    public class AppDbContext : DbContext
    {
        private string _connectionString;

        public AppDbContext(ConnectionSettings connectionSettings)
        {
            _connectionString = connectionSettings.GetConnection();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_connectionString);
        }

        public DbSet<Model.Modifier> Modifiers { get; set; } // line 20
    }
}

