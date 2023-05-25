using System;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Threading.Tasks;
using MauiApp3.Connection;

namespace MauiApp3
{
    public partial class SQLQueryPage : ContentPage
    {
        private ConnectionSettings _connectionSettings;

        public SQLQueryPage()
        {
            InitializeComponent();
            _connectionSettings = new ConnectionSettings();
            _connectionSettings.Deserialize();
        }

        private async void OnExecuteClicked(object sender, EventArgs e)
        {
            // Here you can get the query string from the Editor and execute it
            var query = QueryEditor.Text;

            // Execute the query and get the result
            var result = await ExecuteQuery(query);

            // Display the result
            ResultLabel.Text = result;
        }

        private async Task<string> ExecuteQuery(string query)
        {
            StringBuilder result = new StringBuilder();
            using (var context = new AppDbContext(_connectionSettings))
            {
                var modifiers = await context.Modifiers.FromSqlRaw(query).ToListAsync(); // line 40

                foreach (var modifier in modifiers)
                {
                    result.AppendLine($"ID: {modifier.Id}, Name: {modifier.Name}");
                }
            }

            return result.ToString();
        }
    }
}
