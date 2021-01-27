﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Data;
using UITMBER.Api.DataModels;
using UITMBER.Api.Repositories.Orders.Dto;

namespace UITMBER.Api.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly UDbContext _dbContext;

        public OrderRepository(UDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderDto> GetOrder(long orderId)
        {
            return await _dbContext.Orders.Where(x => x.Id == orderId)
                 .Select(x => new OrderDto()
                 {
                     Id = x.Id,
                     StartLat = x.StartLat,
                     EndLat = x.EndLat,
                     StartLong = x.StartLong,
                     EndLong = x.EndLong,
                     Cost = x.Cost,
                     CreationTime = x.CreationTime
                 }).FirstOrDefaultAsync();
        }

        public bool OrderAccept(long id, DateTime date)
        {
            //Change OrderStatus to Start (1)

            Order order = _dbContext.Orders.Where(x => x.Id == id).FirstOrDefault();
            if (order != null) // && order.Status == (Enums.OrderStatus)5) ?
            {
                order.Status = (Enums.OrderStatus) 1;
                order.StartTime = date;
                _dbContext.Entry(order).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
