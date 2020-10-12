using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Configuration;
using api.Database;
using api.Models;
using MongoDB.Driver;

namespace api.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMongo _database;

        public MenuService(IMongo database)
        {
            _database = database;
        }

        public Menu GetMenu()
        {
            var allDishes = _database.Dishes.Find(_ => true).ToEnumerable();
            var allExtras = _database.Extras.Find(_ => true).ToEnumerable();
            return new Menu
            {
                Extras = allExtras,
                Dishes = allDishes
            };
        }

    }
}
