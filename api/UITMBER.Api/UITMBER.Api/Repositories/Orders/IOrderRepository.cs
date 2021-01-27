using System.Collections.Generic;
using System.Threading.Tasks;
using UITMBER.Api.DataModels;

namespace UITMBER.Api.Repositories.Orders
{
    public interface IOrderRepository
    {
        Task<List<OrdersDto>> GetMyOrders(long userId);
        Task<List<OrdersDto>> GetCarTypes(long userId);
        Task<List<OrdersDto>> GetClientOrderDetails(long userId);
    }
}
