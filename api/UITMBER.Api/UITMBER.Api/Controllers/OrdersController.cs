using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UITMBER.Api.DataModels;
using UITMBER.Api.Repositories.Orders;

namespace UITMBER.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public  Task<List<OrdersDto>> GetMyOrders()
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);

            return _orderRepository.GetMyOrders(userId);
        }
        
        [HttpGet]
        public Task<List<OrdersDto>> GetCarTypes()
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);

            return _orderRepository.GetCarTypes(userId);
        }

        [HttpGet]
        public Task<List<OrdersDto>> GetClientOrderDetails()
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);

            return _orderRepository.GetClientOrderDetails(userId);
        }

    }
}
