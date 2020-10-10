using System.Collections.Generic;
using System.Globalization;

namespace gui.ApiClient.Models
{
    public class Menu
    {
        public IEnumerable<Dish> Dishes { get; set; }
        public IEnumerable<Extras> Extras { get; set; }
    }

    public class Dish
    {
        public string DishIdentifier { get; set; }
        public string DishName { get; set; }
        public decimal DishPrice { get; set; }
        public string DishCategory { get; set; }
    }

    public class Extras
    {
        public string ExtrasIdentifier { get; set; }
        public string ExtrasName { get; set; }
        public decimal ExtrasPrice { get; set; }
        public string DishCategory { get; set; }

        public override string ToString()
        {
            return $"{ExtrasName} - {ExtrasPrice.ToString("C", new CultureInfo("PL"))}";
        }
    }
}
