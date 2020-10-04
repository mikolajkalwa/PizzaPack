using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class OrderDishObject
    {
        public int DishIdentifier { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<OrderAdditiveObject> Additives { get; set; }
    }
}
