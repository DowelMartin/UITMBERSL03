using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.DataModels;
using UTIMBER.Api.Repositories.Applications.Dto;

namespace UTIMBER.Api.Repositories.Applications
{
    public interface IUserAplicationRepository
    {
        Task<List<UserApplicationDto>> GetMyApplications();
        //IEnumerable<UserApplication> GetMyApplications();
        void SendApplication(UserApplicationDto obj);
    }
}
