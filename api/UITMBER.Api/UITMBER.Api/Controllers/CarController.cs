using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Repositories.Cars;
using UITMBER.Api.Repositories.Cars.Dto;

namespace UITMBER.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Driver")]
        public Task<List<CarDto>> GetMyCars()
        {
            //Pobieranie id usera z tokenu
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);

            return _carRepository.GetMyCars(userId);
        }
    }
}
