using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace MauiApp3
{
    public class OrderDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<OrderDatabase> Instance =
            new AsyncLazy<OrderDatabase>(async () => 
            {
                var instance = new OrderDatabase();
                CreateTableResult result1 = await Database.CreateTableAsync<Order>();
                CreateTableResult result2 = await Database.CreateTableAsync<OrderModifier>();
                return instance;
            });

        public OrderDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags); 
        }
        public Task<List<Modifier>> GetModifiersAsync()
        {
            return Database.Table<Modifier>().ToListAsync();
        }


        public Task<List<Order>> GetOrdersAsync()
        {
            return Database.Table<Order>().ToListAsync();
        }

        public Task<List<OrderModifier>> GetOrderModifiersAsync()
        {
            return Database.Table<OrderModifier>().ToListAsync();
        }
    }
}
