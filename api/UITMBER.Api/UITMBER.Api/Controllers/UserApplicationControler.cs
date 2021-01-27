using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.DataModels;
using UTIMBER.Api.Repositories.Applications;
using UTIMBER.Api.Repositories.Applications.Dto;

namespace UTIMBER.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserApplicationControler : ControllerBase
    {
        private readonly IUserAplicationRepository _userAplicationRepository;

        public UserApplicationControler(IUserAplicationRepository userAplicationRepository)
        {
            _userAplicationRepository = userAplicationRepository;
        }

        [HttpGet]
        public Task<List<UserApplicationDto>> GetMyAplication()
        {
            var userId = Convert.ToInt32(User.FindFirst("UserId")?.Value);

            return _userAplicationRepository.GetMyApplications(userId);

        }

        [HttpPost]
        public void SendUserApplication(UserApplicationDto obj)
        {
            _userAplicationRepository.SendApplication(obj);
        }
    }
}
