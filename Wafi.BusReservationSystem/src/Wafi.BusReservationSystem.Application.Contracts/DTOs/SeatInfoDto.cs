using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wafi.BusReservationSystem.Domain.Enums;

namespace Wafi.BusReservationSystem.Application.Contracts.DTOs
{
    public class SeatInfoDto
    {
        public Guid SeatId { get; set; }
        public string SeatNumber { get; set; }
        public SeatStatus Status { get; set; }
    }
}
