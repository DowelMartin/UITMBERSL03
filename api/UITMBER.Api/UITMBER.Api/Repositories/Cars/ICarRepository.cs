using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.DataModels;
using UITMBER.Api.Repositories.Cars.Dto;

namespace UITMBER.Api.Repositories.Cars
{
    public interface ICarRepository
    {
        Task<List<CarDto>> GetMyCars(long userId);
        Task AddCar(Car car);
        Task UpdateCar(Car car);
        Task DeleteCar(long Id);
    }
}
