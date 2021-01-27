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
        public async Task<IEnumerable<DriverDto>> GetNerbyDriveresAsync(double latitude, double longitude) {

            List<DriverDto> drivers = await _driverRepository.GetDrivers();
            return drivers.Where(driver => Double.Equals(driver.Lat,latitude) && Double.Equals(driver.Long,longitude));
        }

        [HttpGet]
        public async Task<DriverDto> GetProfile(int id)
        {
            List<DriverDto> drivers = await _driverRepository.GetDrivers();
            return drivers.Where(driver => driver.Id==id).FirstOrDefault();
        }
    }
}
