using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class OrdersHistoryEntry
    {
        public long OrderId { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public DateTime OrderTime { get; set; }
        public IEnumerable<OrderedDish> Dishes { get; set; }
    }

    public class OrderedDish
    {
        public string Name { get; set; }
        public int Quntity { get; set; }
        public IEnumerable<OrderedAdditive> Additives { get; set; }
    }

    public class OrderedAdditive
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
