using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;

namespace api.Helpers
{
    public interface IOrdersServiceHelpers
    {
        Task<Dish> GetDishById(string dishId);
        Task<Extras> GetExtrasById(string extrasId);
        Task<decimal> CalculateOrderValue(IEnumerable<DishOrder> dishesInOrder);
    }
}