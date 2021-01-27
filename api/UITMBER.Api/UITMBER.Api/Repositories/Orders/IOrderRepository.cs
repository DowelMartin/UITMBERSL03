using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Repositories.Orders.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using UITMBER.Api.DataModels;

namespace UITMBER.Api.Repositories.Orders
{
    public interface IOrderRepository
    {
        public Task<OrderDto> GetOrder(long orderId);
        public bool OrderAccept(long id, DateTime date);
        Task<List<OrdersDto>> GetMyOrders(long userId);
        Task<List<OrdersDto>> GetCarTypes(long userId);
        Task<List<OrdersDto>> GetClientOrderDetails(long userId);
    }
}
