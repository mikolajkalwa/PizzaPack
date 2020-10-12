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

        public async Task<Menu> GetMenu()
        {
            var getAllDishes = _database.Dishes.Find(_ => true).ToListAsync();
            var getAllExtras = _database.Extras.Find(_ => true).ToListAsync();

            await Task.WhenAll(getAllDishes, getAllExtras);
            
            return new Menu
            {
                Extras = getAllExtras.Result,
                Dishes = getAllDishes.Result
            };
        }

    }
}
