using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OrderIdentifier { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Email { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Notes { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal TotalPrice { get; set; }
        public IList<OrderedDish> Dishes { get; set; }
    }

    public class OrderedDish
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string DishIdentifier { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        [BsonRepresentation(BsonType.Int32)]
        public int Quantity { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
        public IList<OrderedExtras>? Extras { get; set; }
    }

    public class OrderedExtras
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string ExtrasIdentifier { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
    }
}
