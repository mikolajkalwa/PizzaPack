using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Menu
    {
        public IEnumerable<DishObject> Dishes { get; set; }
        public IEnumerable<AdditiveObject> Additives { get; set; }
    }

    public class DishObject
    {
        public int DishIdentifier { get; set; }
        public string DishName { get; set; }
        public decimal DishPrice { get; set; }
        public string DishCategory { get; set; }
    }

    public class AdditiveObject
    {
        public int AdditiveIdentifier { get; set; }
        public string AdditiveName { get; set; }
        public decimal AdditivePrice { get; set; }
        public string DishCategory { get; set; }
    }
}
