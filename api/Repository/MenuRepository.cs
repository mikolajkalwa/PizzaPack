using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace api.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly string _connectionString;

        public MenuRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IEnumerable<AdditiveObject> GetAllAdditives()
        {
            var additives = new List<AdditiveObject>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("select additive_id, additive_name, additive_price, dish_category from additives", connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        additives.Add(new AdditiveObject
                        {
                            AdditiveIdentifier = reader.GetInt32(0),
                            AdditiveName = reader.GetString(1),
                            AdditivePrice = reader.GetDecimal(2),
                            DishCategory = reader.GetString(3)
                        });
                    }
                }
            }

            return additives;
        }

        private IEnumerable<DishObject> GetAllDishes()
        {
            var dishes = new List<DishObject>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("select dish_id, dish_name, dish_price, category from menu", connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dishObject = new DishObject
                        {
                            DishIdentifier = reader.GetInt32(0),
                            DishName = reader.GetString(1),
                            DishPrice = reader.GetDecimal(2),
                            DishCategory = reader.GetString(3)
                        };

                        dishes.Add(dishObject);
                    }
                }
            }

            return dishes;
        }

        public Menu GetMenu()
        {
            var dishes = GetAllDishes();
            var additives = GetAllAdditives();
            var menu = new Menu
            {
                Additives = additives,
                Dishes = dishes
            };

            return menu;
        }
    }
}
