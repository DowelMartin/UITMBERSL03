using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.DataModels;

namespace UTIMBER.Api.Repositories.Applications.Dto
{
    public class UserApplicationDto
    {
        public long Id { get; set; }
        //public User User { get; set; }
        public long UserId { get; set; }

        public DateTime Date { get; set; }
        public bool Accepted { get; set; }
        //public Car Car { get; set; }
        public long CarId { get; set; }
    }
}
