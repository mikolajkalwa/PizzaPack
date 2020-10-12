using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Services;

namespace api.Helpers
{
    public class OrdersServiceHelpers : IOrdersServiceHelpers
    {
        private readonly IMenuService _menuService;

        public OrdersServiceHelpers(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public async Task<Dish> GetDishById(string dishId)
        {
            var menu = await _menuService.GetMenu();
            var menuEntryForOrderedDish = menu.Dishes.SingleOrDefault(d => d.DishIdentifier == dishId);

            if (menuEntryForOrderedDish == null)
            {
                throw new ArgumentException($"Dish with identifier {dishId} does not exists!");
            }

            return menuEntryForOrderedDish;
        }

        public async Task<Extras> GetExtrasById(string extrasId)
        {
            var menu = await _menuService.GetMenu();
            var menuEntryForOrderedExtras = menu.Extras.SingleOrDefault(e => e.ExtrasIdentifier == extrasId);

            if (menuEntryForOrderedExtras == null)
            {
                throw new ArgumentException($"Extras with identifier {extrasId} does not exists!");
            }

            return menuEntryForOrderedExtras;
        }

        public async Task<decimal> CalculateOrderValue(IEnumerable<DishOrder> dishesInOrder)
        {
            decimal price = 0;
            foreach (var dishOrder in dishesInOrder)
            {
                decimal extrasPrice = 0;
                var selectedDish = await GetDishById(dishOrder.DishIdentifier);
                if (dishOrder.Extras != null && dishOrder.Extras.Any())
                {
                    foreach (var dishOrderExtra in dishOrder.Extras)
                    {
                        var chosenExtras = await GetExtrasById(dishOrderExtra);
                        extrasPrice += chosenExtras.ExtrasPrice;
                    }
                }

                price += (selectedDish.DishPrice + extrasPrice) * dishOrder.Quantity;
            }
            return price;
        }

    }
}
