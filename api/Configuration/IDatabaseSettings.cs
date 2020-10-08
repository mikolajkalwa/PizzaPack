using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Configuration
{
    public interface IDatabaseSettings
    {
        string DishesCollectionName { get; set; }
        string ExtrasCollectionName { get; set; }
        string OrdersCollectionName { get; set; }
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
