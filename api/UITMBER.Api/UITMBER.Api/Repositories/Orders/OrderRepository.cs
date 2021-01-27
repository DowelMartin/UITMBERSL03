using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Data;
using UITMBER.Api.DataModels;
using UITMBER.Api.Repositories.Orders;



namespace UITMBER.Api.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly UDbContext _dbContext;

        public OrderRepository(UDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OrdersDto>> GetMyOrders(long userId)
        {
                return await _dbContext.Orders.Where(x => x.UserId == userId)
                .Select(x => new OrdersDto()
                {
                    UserId = x.UserId,
                    ClientRating = x.ClientRating,
                    DriverRating = x.DriverRating,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    Photo = x.User.Photo,
                    PhoneNumber = x.User.PhoneNumber

                }).ToListAsync();
        }

        public async Task<List<OrdersDto>> GetCarTypes(long userId) 
        {
            return await _dbContext.Cars.Where(x => x.UserId == userId)
                .Select(x => new OrdersDto()
                {
                    UserId = x.UserId,
                    Type = x.Type

                }).ToListAsync();
        }

        public async Task<List<OrdersDto>> GetClientOrderDetails(long userId)
        {
            return await _dbContext.Orders.Where(x => x.UserId == userId)
                .Select(x => new OrdersDto()
                {
                    UserId = x.UserId,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    Photo = x.User.Photo,
                    PhoneNumber = x.User.PhoneNumber,
                    StartLat = x.StartLat,
                    EndLat = x.EndLat,
                    StartLong = x.StartLong,
                    EndLong = x.EndLong,
                    Cost = x.Cost,
                    DriverRating = x.DriverRating
                    

                }).ToListAsync();
        }
    }
}
