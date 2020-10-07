using System;
using api.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace api.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IMongoCollection<Order> _orders;
        private readonly IMenuService _menuService;

        public OrdersService(IDatabaseSettings settings, IMenuService menuService)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _menuService = menuService;
            _orders = database.GetCollection<Order>(settings.OrdersCollectionName);
        }

        public IEnumerable<Order> GetOrdersHistory()
        {
            return _orders.Find(_ => true).ToList();
        }

        public Order CreateOrder(PlaceOrder order)
        {
            decimal totalPrice = 0;

            var placedOrder = new Order { Dishes = new List<OrderedDish>() };

            var menu = _menuService.GetMenu();

            foreach (var orderedDish in order.Dishes)
            {

                var menuEntryForOrderedDish = menu.Dishes.Single(d => d.DishIdentifier == orderedDish.DishIdentifier);

                decimal orderedExtrasPrice = 0;
                List<OrderedExtras> orderedExtrasForDish = null;

                if (orderedDish.Extras != null)
                {
                    orderedExtrasForDish = new List<OrderedExtras>();
                    foreach (var orderedExtras in orderedDish.Extras)
                    {
                        var menuEntryForOrderedExtras = menu.Extras.Single(e => e.ExtrasIdentifier == orderedExtras);

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

            _orders.InsertOne(placedOrder);
            return placedOrder;
        }
    }
}
