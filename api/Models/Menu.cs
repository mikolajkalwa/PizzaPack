using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Menu
    {
        public IEnumerable<Dish> Dishes { get; set; }
        public IEnumerable<Extras> Extras { get; set; }
    }

    public class Dish
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DishIdentifier { get; set; }
        public string DishName { get; set; }
        public decimal DishPrice { get; set; }
        public string DishCategory { get; set; }
    }

    public class Extras
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ExtrasIdentifier { get; set; }
        public string ExtrasName { get; set; }
        public decimal ExtrasPrice { get; set; }
        public string DishCategory { get; set; }
    }
}
