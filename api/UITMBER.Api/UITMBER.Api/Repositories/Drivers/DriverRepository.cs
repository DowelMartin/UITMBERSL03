using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Data;
using UITMBER.Api.Repositories.Cars.Dto;
using UITMBER.Api.Repositories.Drivers.Dto;

namespace UITMBER.Api.Repositories.Drivers
{
    public class DriverRepository : IDriverRepository
    {
        private readonly UDbContext _dbContext;

        public DriverRepository(UDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DriverDto>> GetDrivers()
        {
            return await _dbContext.Users.Where(x => x.IsWorking && x.IsDriver)
                 .Select(x => new DriverDto()
                 {
                     Id = x.Id,
                     Email = x.Email,
                     FirstName = x.FirstName,
                     LastName = x.LastName,
                     Lat = x.Lat,
                     Long = x.Long,
                     PhoneNumber = x.PhoneNumber,
                     Photo = x.Photo
                 }).ToListAsync();
        }
    }
}
