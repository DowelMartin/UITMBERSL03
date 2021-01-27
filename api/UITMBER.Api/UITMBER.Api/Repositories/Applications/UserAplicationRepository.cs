using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.DataModels;
using UITMBER.Api.Data;
using UTIMBER.Api.Repositories.Applications.Dto;

namespace UTIMBER.Api.Repositories.Applications
{
    public class UserAplicationRepository : IUserAplicationRepository
    {
        private readonly UDbContext _dbContext;

        public UserAplicationRepository(UDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserApplicationDto>> GetMyApplications(long userId)
        {
            return await _dbContext.UserApplications.Where(x => x.UserId == userId)
                .Select(x => new UserApplicationDto()
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Date = x.Date,
                    Accepted = x.Accepted,
                    CarId = x.CarId
                }).ToListAsync();
        }

        public void SendApplication(UserApplicationDto obj)
        {
            UserApplication objToAdd = new UserApplication();
            objToAdd.UserId = obj.UserId;
            objToAdd.Date = obj.Date;
            objToAdd.Accepted = false;
            objToAdd.CarId = obj.CarId;

            _dbContext.UserApplications.Add(objToAdd);
            _dbContext.SaveChanges();
        }
    }
}
