using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using System.Linq;

namespace MauiApp3
{
    public class OrderPageViewModel : BaseViewModel
    {
        private IOrderService OrderService { get; }
        private AppDbContext _dbContext;
        public IRelayCommand<string> SelectFoodItemCommand { get; }
        public IRelayCommand<string> ToggleModifierCommand { get; }
        public IRelayCommand FinishOrderCommand { get; }

        public Order CurrentOrder { get; set; }
        private List<string> SelectedModifiers { get; set; } = new List<string>();
        public IEnumerable<string> Modifiers { get; private set; }

        public OrderPageViewModel(IOrderService orderService, AppDbContext appDbContext)
        {
            OrderService = orderService;
            _dbContext = appDbContext;
            SelectFoodItemCommand = new RelayCommand<string>(SelectFoodItem);
            ToggleModifierCommand = new RelayCommand<string>(ToggleModifier);
            FinishOrderCommand = new RelayCommand(FinishOrder);

            using var context = App.ServiceProvider.GetRequiredService<AppDbContext>();
            Modifiers = context.Modifiers.Select(m => m.Name).ToList(); // line 29
        }


        private void SelectFoodItem(string mainFoodItem)
        {
            // Create a new Order object
            CurrentOrder = new Order
            {
                MainFoodItem = mainFoodItem,
                Modifiers = SelectedModifiers // This field will be populated later with selected modifiers
            };
        }

        private void ToggleModifier(string modifier)
        {
            // Add modifier if not already selected, remove if it is
            if (SelectedModifiers.Contains(modifier))
            {
                SelectedModifiers.Remove(modifier);
            }
            else
            {
                SelectedModifiers.Add(modifier);
            }
        }

        private void FinishOrder()
        {
            // Fill in the modifiers for the current order
            CurrentOrder.Modifiers = SelectedModifiers;

            // Add the order to the MainPageViewModel's Orders collection
            ((App.Current.MainPage as Shell).CurrentPage.BindingContext as MainPageViewModel).Orders.Add(CurrentOrder);

            // Clear the current order and selected modifiers for next order
            CurrentOrder = null;
            SelectedModifiers.Clear();
        }
    }
}
