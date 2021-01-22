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

    [Route("[controller]")]
    [ApiController]
    public class UserApplicationControler
    {
        private readonly IUserAplicationRepository _userAplicationRepository;

        public UserApplicationControler(IUserAplicationRepository userAplicationRepository)
        {
            _userAplicationRepository = userAplicationRepository;
        }

        [HttpGet]
        public Task<List<UserApplicationDto>> GetAll()
        {
            return _userAplicationRepository.GetMyApplications();

        }

        [HttpPost]
        public void SendUserApplication(UserApplicationDto obj)
        {
            _userAplicationRepository.SendApplication(obj);
        }
    }
}
