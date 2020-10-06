using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class PlaceOrder
    {
        public string Notes { get; set; }
        public string Email { get; set; }
        public DateTime OrderTime { get; set; }
        public IEnumerable<OrderDishObject> Dishes { get; set; }
    }

    public class OrderDishObject
    {
        public int DishIdentifier { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<OrderAdditiveObject> Additives { get; set; }
    }

    public class OrderAdditiveObject
    {
        public int AdditiveIdentifier { get; set; }
        public int Quantity { get; set; }
    }
}
