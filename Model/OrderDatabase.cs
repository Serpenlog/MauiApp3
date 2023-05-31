using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MauiApp3;

namespace MauiApp3
{
    public class OrderDatabase
    {
        static SQLiteAsyncConnection Database;

        public static OrderDatabase Instance { get; private set; }

        public OrderDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public static async Task InitAsync()
        {
            if (Instance != null)
            {
                Instance = new OrderDatabase();
                await Database.CreateTableAsync<Order>();
                await Database.CreateTableAsync<OrderModifier>();
                await Database.CreateTableAsync<Modifier>();
            }
        }

        public async Task<List<Modifier>> GetModifiersAsync()
        {
            await InitAsync();
            return await Database.Table<Modifier>().ToListAsync();
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            await InitAsync();
            return await Database.Table<Order>().ToListAsync();
        }

        public async Task<List<OrderModifier>> GetOrderModifiersAsync()
        {
            await InitAsync();
            return await Database.Table<OrderModifier>().ToListAsync();
        }
    }
}
