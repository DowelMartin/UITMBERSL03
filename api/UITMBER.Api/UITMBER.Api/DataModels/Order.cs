using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UITMBER.Api.Enums;

namespace UITMBER.Api.DataModels
{
    public class Order
    {
        public long Id { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public long UserId { get; set; }

        public DateTime CreationTime { get; set; }

        [ForeignKey(nameof(DriverId))]
        public User Driver { get; set; }
        public long? DriverId { get; set; }

        public double StartLat { get; set; }
        public double StartLong { get; set; }
        public double EndLat { get; set; }
        public double EndLong { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }


        public OrderStatus Status { get; set; }

        public double Cost { get; set; }

        public double? ClientRating { get; set; }
        public double? DriverRating { get; set; }

    }
}
