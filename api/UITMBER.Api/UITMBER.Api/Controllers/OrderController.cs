using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UITMBER.Api.Repositories.Orders;
using UITMBER.Api.Repositories.Orders.Dto;

namespace UITMBER.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET GetCost api/<OrderController>
        [HttpGet]
        public async Task<double> GetCost(long orderId, DateTime date, double distance)
        {
            OrderDto order = await _orderRepository.GetOrder(orderId);
            var cost_per_hour = order.Cost;
            var order_date = order.CreationTime;
            var weekend_cost = 1.3;
            var cost = (order_date.DayOfWeek >= DayOfWeek.Monday && order_date.DayOfWeek <= DayOfWeek.Friday) ? distance * cost_per_hour : (distance * cost_per_hour) * weekend_cost;
            return cost;
        }

        // POST OrderAccept api/<OrderController>
        [HttpPost]
        public IActionResult OrderAccept(long id, DateTime date)
        {
            bool order_accepted = _orderRepository.OrderAccept(id, date);
            if (order_accepted) return Ok();
            return NotFound("Order not found");
        }
    }
}
