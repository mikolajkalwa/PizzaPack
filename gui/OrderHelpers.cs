﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Windows.Forms;
using gui.ApiClient;
using gui.ApiClient.Models;
using MongoDB.Bson;

namespace gui
{
    public class OrderHelpers
    {
        private readonly Menu _menu;
        public OrderHelpers(IPizzeriaApiClient client)
        {
            _menu = client.GetMenu();
        }

        public decimal CalculateOrderValue(IEnumerable<DishOrder> dishesInOrder)
        {
            decimal price = 0;
            foreach (var dishOrder in dishesInOrder)
            {
                decimal extrasPrice = 0;
                var selectedDish = GetDishById(dishOrder.DishIdentifier);
                if (dishOrder.Extras != null && dishOrder.Extras.Any())
                {
                    foreach (var dishOrderExtra in dishOrder.Extras)
                    {
                        var chosenExtras = GetExtrasById(dishOrderExtra);
                        extrasPrice += chosenExtras.ExtrasPrice;
                    }
                }

                price += (selectedDish.DishPrice + extrasPrice) * dishOrder.Quantity;

            }

            return price;
        }

        public Dish GetDishById(string dishId)
        {
            return _menu.Dishes.First(dish =>
                dish.DishIdentifier == dishId);
        }

        public Extras GetExtrasById(string extrasId)
        {
            return _menu.Extras.First(extra => extra.ExtrasIdentifier == extrasId);
        }

        public IList<Extras> GetAvailableExtrasForCategory(string dishCategory)
        {
            return _menu.Extras.Where(extras => extras.DishCategory == dishCategory).ToList();
        }

        public bool TryConvertObjectIdToDateTime(string objectId, out DateTime dateTime)
        {
            dateTime = new DateTime();
            var result = ObjectId.TryParse(objectId, out var tmp);
            if (!result)
            {
                return false;
            }

            dateTime = tmp.CreationTime;
            return true;
        }
    }
}
