using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.DataModels;
using UITMBER.Api.Repositories.Cars;
using UITMBER.Api.Repositories.Cars.Dto;

namespace UITMBER.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public Task<List<CarDto>> GetMyCars(int userId = 1)
        {
            //Pobieranie id usera z tokenu
            //var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);

            return _carRepository.GetMyCars(userId);
        }

        [HttpPost]
        public Task AddCar(Car car)
        {
            return _carRepository.AddCar(car);
        }

        [HttpPut("{id}")]
        public Task UpdateCar(Car car)
        {
            return _carRepository.UpdateCar(car);
        }

        [HttpDelete("{id}")]
        public Task DeleteCar(long id)
        {
            return _carRepository.DeleteCar(id);
        }



    }
}
