using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using System.Diagnostics;
using System.Collections.Generic;
using MauiApp3;

namespace MauiApp3
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Order> _orders;

        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set => SetProperty(ref _orders, value);
        }

        public IRelayCommand BumpOrderCommand { get; }
        public IRelayCommand GoToOrderPageCommand { get; }
        public IRelayCommand GoToSQLQueryPageCommand { get; }

        public MainPageViewModel()
        {
            BumpOrderCommand = new RelayCommand<Order>(BumpOrder);
            GoToOrderPageCommand = new RelayCommand(GoToOrderPage);
            GoToSQLQueryPageCommand = new RelayCommand(GoToSQLQueryPage);

            Orders = new ObservableCollection<Order>
                {
                    new Order { MainFoodItems = new MainFoodItem { Name = "Burger", Modifiers = new List<string>{ "No onions", "Extra cheese" } } },
                    new Order { MainFoodItems = new MainFoodItem { Name = "Pizza", Modifiers = new List<string>() } },
                };
        }

        private async void GoToSQLQueryPage()
        {
            // Navigate to SQLQueryPage
            try
            {
                await Shell.Current.GoToAsync(nameof(SQLQueryPage));
            }
            catch (Exception ex)
            {
                // log the exception
                Debug.WriteLine(ex.ToString());
            }
        }
        private void BumpOrder(Order order)
        {
            Orders.Remove(order);
        }

        private async void GoToOrderPage()
        {
            // Navigate to OrderPage
            // await Shell.Current.GoToAsync(nameof(OrderPage));
            try
            {
                await Shell.Current.GoToAsync(nameof(OrderPage));
            }
            catch (Exception ex)
            {
                // log the exception
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
