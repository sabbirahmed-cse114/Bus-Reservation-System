using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wafi.BusReservationSystem.Application.Contracts.DTOs
{
    public class AvailableBusDto
    {
        public Guid BusScheduleId { get; set; }
        public Guid BusId { get; set; }
        public string BusName { get; set; } = null!;
        public string CompanyName { get; set; }
        public DateTime JourneyDate { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public decimal Price { get; set; }
        public int SeatsLeft { get; set; }
        public int TotalSeats { get; set; }
        public Guid RouteId { get; set; }
        public string RouteName { get; set; }
        public Guid BoardingPointId { get; set; }
        public Guid DroppingPointId { get; set; }
    }
}
