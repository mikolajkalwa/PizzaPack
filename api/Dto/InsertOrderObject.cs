using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class InsertOrderObject
    {
        public string Notes { get; set; }
        public string Email { get; set; }
        public DateTime OrderTime { get; set; }
        public IEnumerable<OrderDishObject> Dishes { get; set; }

    }
}
