using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class Menu
    {
        public IEnumerable<DishObject> Dishes { get; set; }
        public IEnumerable<AdditiveObject> Additives { get; set; }
    }
}
