using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Repositories.Cars.Dto;

namespace UITMBER.Api.Repositories.Cars
{
    public interface ICarRepository
    {
        Task<List<CarDto>> GetMyCars(long userId);
    }
}
