using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Configuration;
using api.Models;
using MongoDB.Driver;

namespace api.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMongoCollection<Dish> _dishes;
        private readonly IMongoCollection<Extras> _extras;

        public MenuService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _dishes = database.GetCollection<Dish>(settings.DishesCollectionName);
            _extras = database.GetCollection<Extras>(settings.ExtrasCollectionName);
        }

        public Menu GetMenu()
        {
            var allDishes = _dishes.Find(_ => true).ToList();
            var allExtras = _extras.Find(_ => true).ToList();
            return new Menu
            {
                Extras = allExtras,
                Dishes = allDishes
            };
        }

    }
}
