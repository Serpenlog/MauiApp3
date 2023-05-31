using System;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Threading.Tasks;
using MauiApp3.Service;

namespace MauiApp3
{
    public partial class SQLQueryPage : ContentPage
    {
        public SQLQueryPage()
        {
            InitializeComponent();
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
            StringBuilder result = new StringBuilder(); // error, 33
            using (var context = new OrderDatabase()) // error, 34
            {
                var modifiers = await context.Modifiers.FromSqlRaw(query).ToListAsync(); // error, 36

                foreach (var modifier in modifiers)
                {
                    result.AppendLine($"ID: {modifier.Id}, Name: {modifier.Name}");
                }
            }

            return result.ToString();
        }
    }
}
