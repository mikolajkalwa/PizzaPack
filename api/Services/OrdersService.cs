using System;
using api.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using api.Configuration;
using api.Database;
using api.Helpers;
using api.Validators;
using FluentValidation.Results;

namespace api.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IMongo _database;
        private readonly IOrdersServiceHelpers _ordersServiceHelpers;

        public OrdersService(IMongo database, IOrdersServiceHelpers ordersServiceHelpers)
        {
            _database = database;
            _ordersServiceHelpers = ordersServiceHelpers;
        }

        public async Task<IEnumerable<Order>> GetOrdersHistory()
        {
            return (await _database.Orders.FindAsync(_ => true)).ToEnumerable().Reverse();
        }


        private async Task ValidateOrder(PlaceOrder order)
        {
            var validator = new PlaceOrderValidator();
            var results = await validator.ValidateAsync(order);

            if (!results.IsValid)
            {
                var message = new StringBuilder();
                foreach (var failure in results.Errors)
                {
                    message.AppendLine(failure.ErrorMessage);
                }
                throw new ArgumentException(message.ToString());
            }

            foreach (var orderedDish in order.Dishes)
            {
                var menuEntryForOrderedDish = await _ordersServiceHelpers.GetDishById(orderedDish.DishIdentifier);

                if (orderedDish.Extras != null)
                {

                    if (orderedDish.Extras.Count != orderedDish.Extras.Distinct().Count())
                    {
                        throw new ArgumentException($"Dish order cannot include duplicated extras");
                    }

                    foreach (var orderedExtras in orderedDish.Extras)
                    {

                        var menuEntryForOrderedExtras = await _ordersServiceHelpers.GetExtrasById(orderedExtras);

                        if (menuEntryForOrderedExtras.DishCategory != menuEntryForOrderedDish.DishCategory)
                        {
                            throw new ArgumentException($"Cannot order extras from category {menuEntryForOrderedExtras.DishCategory} for dish from category {menuEntryForOrderedDish.DishCategory}");
                        }
                    }
                }

            }
        }

        public async Task<Order> CreateOrder(PlaceOrder order)
        {
            await ValidateOrder(order);

            var placedOrder = new Order { Dishes = new List<OrderedDish>() };

            foreach (var orderedDish in order.Dishes)
            {
                var menuEntryForOrderedDish = await _ordersServiceHelpers.GetDishById(orderedDish.DishIdentifier);
                List<OrderedExtras> orderedExtrasForDish = null;

                if (orderedDish.Extras != null)
                {
                    orderedExtrasForDish = new List<OrderedExtras>();

                    foreach (var orderedExtras in orderedDish.Extras)
                    {

                        var menuEntryForOrderedExtras = await _ordersServiceHelpers.GetExtrasById(orderedExtras);

                        orderedExtrasForDish.Add(new OrderedExtras
                        {
                            ExtrasIdentifier = orderedExtras,
                            Name = menuEntryForOrderedExtras.ExtrasName,
                            Price = menuEntryForOrderedExtras.ExtrasPrice
                        });
                    }
                }

                placedOrder.Dishes.Add(new OrderedDish
                {
                    Extras = orderedExtrasForDish,
                    Price = menuEntryForOrderedDish.DishPrice,
                    DishIdentifier = menuEntryForOrderedDish.DishIdentifier,
                    Quantity = orderedDish.Quantity,
                    Name = menuEntryForOrderedDish.DishName
                });

            }

            decimal totalPrice = await _ordersServiceHelpers.CalculateOrderValue(order.Dishes);

            placedOrder.Email = order.Email;
            placedOrder.Notes = order.Notes;
            placedOrder.TotalPrice = totalPrice;

            await _database.Orders.InsertOneAsync(placedOrder);
            return placedOrder;
        }
    }
}
