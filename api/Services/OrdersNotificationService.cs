using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.Extensions.Logging;

namespace api.Services
{
    public class OrdersNotificationService : IOrdersService
    {
        private readonly IOrdersService _ordersService;
        private readonly INotificationService _notificationService;
        public OrdersNotificationService(IOrdersService ordersService, INotificationService notificationService)
        {
            _ordersService = ordersService;
            _notificationService = notificationService;
        }
        public async Task<Order> CreateOrder(PlaceOrder order)
        {
            var placedOrder = await _ordersService.CreateOrder(order);
            await _notificationService.SendNotification(order.Email, placedOrder);
            return placedOrder;
        }

        public Task<IEnumerable<Order>> GetOrdersHistory()
        {
            return _ordersService.GetOrdersHistory();
        }
    }
}
