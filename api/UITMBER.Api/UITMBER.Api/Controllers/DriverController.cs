using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UITMBER.Api.Data;
using UITMBER.Api.DataModels;
using UITMBER.Api.Repositories.Drivers;
using UITMBER.Api.Repositories.Drivers.Dto;

namespace UITMBER.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverRepository _driverRepository;

        public DriverController(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<DriverDto>> GetNerbyDriveresAsync(double latitude, double longitude, double maxDistance=1) {

            List<DriverDto> drivers = await _driverRepository.GetDrivers();
            return drivers.Where(driver => CalculateDistance(latitude, longitude, driver.Lat, driver.Long) <= maxDistance);
        }
        private double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        [HttpGet]
        public async Task<DriverDto> GetProfile(int id)
        {
            List<DriverDto> drivers = await _driverRepository.GetDrivers();
            return drivers.Where(driver => driver.Id==id).FirstOrDefault();
        }
    }
}
