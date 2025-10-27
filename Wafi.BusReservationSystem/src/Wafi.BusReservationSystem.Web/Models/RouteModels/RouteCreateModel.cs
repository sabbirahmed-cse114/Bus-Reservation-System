using Microsoft.AspNetCore.Mvc.Rendering;
using Wafi.BusReservationSystem.Domain.Entities;
using Wafi.BusReservationSystem.Infrastructure.Utility;

namespace Wafi.BusReservationSystem.Web.Models.RouteModels
{
    public class RouteCreateModel
    {
        public string? Name { get; set; } 
        public Guid? BoardingPointId { get; set; }
        public IList<SelectListItem>? BoardingPoints { get; private set; }
        public int Order { get; set; }
        public double Distance { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan DepartureTime { get; set; }

        public List<RouteDroppingPointModel>? DroppingPoints { get; set; } = new();

        public void SetBoardingPointsValues(IList<City> boardingPoints)
        {
            BoardingPoints = boardingPoints.ToSelectList(x => x.Name, y => y.Id);
        }
    }
}
