using api.Models;
using MongoDB.Driver;

namespace api.Database
{
    public interface IMongo
    {
        IMongoCollection<Dish> Dishes { get; set; }
        IMongoCollection<Extras> Extras { get; set; }
        IMongoCollection<Order> Orders { get; set; }
    }
}