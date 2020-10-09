using System.Collections.Generic;

namespace gui.ApiClient.Models
{
    public class Order
    {
        public string OrderIdentifier { get; set; }

        public string Email { get; set; }

        public string Notes { get; set; }

        public decimal TotalPrice { get; set; }
        public IList<OrderedDish> Dishes { get; set; }
    }

    public class OrderedDish
    {
        public string DishIdentifier { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
        public IList<OrderedExtras>? Extras { get; set; }
    }

    public class OrderedExtras
    {
        public string ExtrasIdentifier { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
