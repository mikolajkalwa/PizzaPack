using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpPost]
        [Route("PlaceOrder")]
        public ActionResult<Order> PlaceOrder([FromBody] PlaceOrder order)
        {
            var placedOrder = _ordersService.CreateOrder(order);
            return Created("GetOrdersHistory", placedOrder);
        }

        [HttpGet]
        [Route("OrdersHistory")]
        public ActionResult<IEnumerable<Order>> OrderHistory()
        {
            return Ok(_ordersService.GetOrdersHistory());
        }
    }
}
