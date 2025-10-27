using System.Web.Mvc;
using Wafi.BusReservationSystem.Domain.Entities;
using Wafi.BusReservationSystem.Infrastructure.Utility;

namespace Wafi.BusReservationSystem.Web.Models.RouteModels
{
    public class RouteDroppingPointModel
    {
        public Guid? RouteId { get; set; }
        public Guid? DroppingPointId { get; set; }
        public IList<SelectListItem>? Cities { get; private set; }
        public int Order {  get; set; }
        public double Distance { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan DepartureTime { get; set; }
    }
}
