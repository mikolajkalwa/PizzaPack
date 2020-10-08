using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Configuration
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string DishesCollectionName { get; set; }
        public string ExtrasCollectionName { get; set; }
        public string OrdersCollectionName { get; set; }
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
