using System;
using System.Collections.Generic;
using System.Text;
using gui.ApiClient.Models;

namespace gui.ApiClient
{
    public interface IRestClient
    {
        Order PlaceOrder(PlaceOrder order);
        Menu GetMenu();
        IEnumerable<Order> GetOrdersHistory();
    }
}
