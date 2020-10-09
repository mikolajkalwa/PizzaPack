using System.Collections.Generic;

namespace gui.ApiClient.Models
{
    public class PlaceOrder
    {
        public string Email { get; set; }
        public string? Notes { get; set; }
        public IList<DishOrder> Dishes { get; set; }
    }

    public class DishOrder
    {
        public string DishIdentifier { get; set; }
        public int Quantity { get; set; }
        public IList<string>? Extras { get; set; }
    }

}
