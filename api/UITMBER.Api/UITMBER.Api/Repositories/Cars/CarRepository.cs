using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Data;
using UITMBER.Api.DataModels;
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

        public async Task AddCar(Car car)
        {
            _dbContext.Cars.Add(car);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCar(Car car)
        {
            var obj = _dbContext.Cars.FirstOrDefault(x => x.Id == car.Id);
            if(obj != null)
            {
                obj.IsActive = car.IsActive;
                obj.Manufacturer = car.Manufacturer;
                obj.Model = car.Model;
                obj.Photo = car.Photo;
                obj.PlateNo = car.PlateNo;
                obj.Type = car.Type;
                obj.Year = car.Year;
            }
            //_dbContext.Cars.Update(obj);
           await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteCar(long Id)
        {
            var obj = _dbContext.Cars.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Cars.Remove(obj);
            await _dbContext.SaveChangesAsync();
        }


    }
}
