using System;
using System.Collections.Generic;
using System.Text;

namespace gui.Models
{
    class SummarizeOrderEntry
    {
        public string DishName { get; set; }
        public int Quantity { get; set; }
        public string Extras { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
