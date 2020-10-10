using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using gui.ApiClient.Models;
using gui.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace gui.ApiClient
{
    public class PizzeriaApiClient : IPizzeriaApiClient
    {
        private readonly RestClient _client;

        public PizzeriaApiClient(IOptions<AppSettings> appSettings)
        {
            _client = new RestClient(appSettings.Value.ApiAddress);
        }
        public Order PlaceOrder(PlaceOrder order)
        {
            RestRequest request = new RestRequest("api/orders/placeorder", Method.POST);
            request.AddJsonBody(order);
            var response = _client.Post(request);

            if (response.StatusCode == HttpStatusCode.Created)
            {
                Order placedOrder = JsonConvert.DeserializeObject<Order>(response.Content);
                return placedOrder;
            }
            throw new Exception(response.ErrorMessage);
        }

        public Menu GetMenu()
        {
            var request = new RestRequest("api/menu", Method.GET);
            var response = _client.Get(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Menu menu = JsonConvert.DeserializeObject<Menu>(response.Content);
                return menu;
            }
            throw new Exception(response.ErrorMessage);
        }

        public IEnumerable<Order> GetOrdersHistory()
        {
            var request = new RestRequest("api/orders/ordershistory", Method.GET);
            var response = _client.Get(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                IEnumerable<Order> ordersHistory = JsonConvert.DeserializeObject<IEnumerable<Order>>(response.Content);
                return ordersHistory;
            }
            throw new Exception(response.ErrorMessage);
        }
    }
}
