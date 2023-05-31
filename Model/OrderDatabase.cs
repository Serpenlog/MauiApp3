using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace MauiApp3.Model
{
    public class OrderDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<OrderDatabase> Instance =
            new AsyncLazy<OrderDatabase>(async () => // error, 15
            {
                var instance = new OrderDatabase();
                CreateTableResult result1 = await Database.CreateTableAsync<Order>();
                CreateTableResult result2 = await Database.CreateTableAsync<OrderModifier>();
                return instance;
            });

        public OrderDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags); // error, 25
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
