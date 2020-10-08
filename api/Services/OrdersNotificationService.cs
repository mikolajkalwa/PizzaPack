using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

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
        public Order CreateOrder(PlaceOrder order)
        {
            var placedOrder = _ordersService.CreateOrder(order);
            _notificationService.SendNotification(order.Email, placedOrder);
            return placedOrder;
        }

        public IEnumerable<Order> GetOrdersHistory()
        {
            return _ordersService.GetOrdersHistory();
        }
    }
}
