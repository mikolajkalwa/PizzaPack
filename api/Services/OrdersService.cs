using System;
using api.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using api.Configuration;
using api.Database;
using api.Validators;
using FluentValidation.Results;

namespace api.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IMongo _database;
        private readonly IMenuService _menuService;

        public OrdersService(IMongo database, IMenuService menuService)
        {
            _database = database;
            _menuService = menuService;
        }

        public IEnumerable<Order> GetOrdersHistory()
        {
            return _database.Orders.Find(_ => true).SortByDescending(order => order.OrderIdentifier).ToEnumerable();
        }

        public Order CreateOrder(PlaceOrder order)
        {
            PlaceOrderValidator validator = new PlaceOrderValidator();
            ValidationResult results = validator.Validate(order);
            
            if (!results.IsValid)
            {
                var message = new StringBuilder();
                foreach (var failure in results.Errors)
                {
                    message.AppendLine(failure.ErrorMessage);
                }
                throw new ArgumentException(message.ToString());
            }

            decimal totalPrice = 0;
            var placedOrder = new Order { Dishes = new List<OrderedDish>() };
            var menu = _menuService.GetMenu();

            foreach (var orderedDish in order.Dishes)
            {

                var menuEntryForOrderedDish = menu.Dishes.SingleOrDefault(d => d.DishIdentifier == orderedDish.DishIdentifier);

                if (menuEntryForOrderedDish == null)
                {
                    throw new ArgumentException($"Dish with identifier {orderedDish.DishIdentifier} does not exists!");
                }

                decimal orderedExtrasPrice = 0;
                List<OrderedExtras> orderedExtrasForDish = null;

                if (orderedDish.Extras != null)
                {
                    orderedExtrasForDish = new List<OrderedExtras>();

                    if (orderedDish.Extras.Count != orderedDish.Extras.Distinct().Count())
                    {
                        throw new ArgumentException($"Dish order cannot include duplicated extras");
                    }

                    foreach (var orderedExtras in orderedDish.Extras)
                    {
                        var menuEntryForOrderedExtras = menu.Extras.SingleOrDefault(e => e.ExtrasIdentifier == orderedExtras);

                        if (menuEntryForOrderedExtras == null)
                        {
                            throw new ArgumentException($"Extras with identifier {orderedExtras} does not exists!");
                        }

                        if (menuEntryForOrderedExtras.DishCategory != menuEntryForOrderedDish.DishCategory)
                        {
                            throw new ArgumentException($"Cannot order extras from category {menuEntryForOrderedExtras.DishCategory} for dish from category {menuEntryForOrderedDish.DishCategory}");
                        }

                        orderedExtrasPrice += menuEntryForOrderedExtras.ExtrasPrice;

                        orderedExtrasForDish.Add(new OrderedExtras
                        {
                            ExtrasIdentifier = orderedExtras,
                            Name = menuEntryForOrderedExtras.ExtrasName,
                            Price = menuEntryForOrderedExtras.ExtrasPrice
                        });
                    }
                }

                totalPrice += (menuEntryForOrderedDish.DishPrice + orderedExtrasPrice) * orderedDish.Quantity;


                placedOrder.Dishes.Add(new OrderedDish
                {
                    Extras = orderedExtrasForDish,
                    Price = menuEntryForOrderedDish.DishPrice,
                    DishIdentifier = menuEntryForOrderedDish.DishIdentifier,
                    Quantity = orderedDish.Quantity,
                    Name = menuEntryForOrderedDish.DishName
                });

            }

            placedOrder.Email = order.Email;
            placedOrder.Notes = order.Notes;
            placedOrder.TotalPrice = totalPrice;

            _database.Orders.InsertOne(placedOrder);
            return placedOrder;
        }
    }
}
