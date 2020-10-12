using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Configuration;
using api.Models;
using MongoDB.Driver;

namespace api.Database
{
    public class Mongo : IMongo
    {
        public IMongoCollection<Dish> Dishes { get; set; }
        public IMongoCollection<Extras> Extras { get; set; }
        public IMongoCollection<Order> Orders { get; set; }

        public Mongo(IDatabaseSettings databaseSettings)
        {
            IMongoClient client = new MongoClient(databaseSettings.ConnectionString);
            var db = client.GetDatabase(databaseSettings.DatabaseName);
            Dishes = db.GetCollection<Dish>(databaseSettings.DishesCollectionName);
            Extras = db.GetCollection<Extras>(databaseSettings.ExtrasCollectionName);
            Orders = db.GetCollection<Order>(databaseSettings.OrdersCollectionName);

        }
    }
}
