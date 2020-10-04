using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto;
using api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        [Route("placeOrder")]
        public ActionResult PlaceOrder([FromBody] InsertOrderObject order)
        {
            order.OrderTime = DateTime.Now;
            _orderRepository.PlaceOrder(order);
            return Ok();
        }
    }
}
