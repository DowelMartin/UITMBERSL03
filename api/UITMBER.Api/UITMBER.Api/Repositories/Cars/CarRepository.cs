using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Data;
using UITMBER.Api.Repositories.Cars.Dto;

namespace UITMBER.Api.Repositories.Cars
{
    public class CarRepository : ICarRepository
    {
        private readonly UDbContext _dbContext;

        public CarRepository(UDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CarDto>> GetMyCars(long userId)
        {
            return await _dbContext.Cars.Where(x => x.IsActive && x.UserId == userId)
                 .Select(x => new CarDto()
                 {
                     Id = x.Id,
                     IsActive = x.IsActive,
                     Manufacturer = x.Manufacturer,
                     Model = x.Model,
                     Photo = x.Photo,
                     PlateNo = x.PlateNo,
                     Type = x.Type,
                     Year = x.Year
                 }).ToListAsync();
        }
    }
}
