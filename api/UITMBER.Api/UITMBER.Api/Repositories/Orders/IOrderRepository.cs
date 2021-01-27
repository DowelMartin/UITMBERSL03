using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Repositories.Orders.Dto;

namespace UITMBER.Api.Repositories.Orders
{
    public interface IOrderRepository
    {
        public Task<OrderDto> GetOrder(long orderId);
        public bool OrderAccept(long id, DateTime date);
    }
}
