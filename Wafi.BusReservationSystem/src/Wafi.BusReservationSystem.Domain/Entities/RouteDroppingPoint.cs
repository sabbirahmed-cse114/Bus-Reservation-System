
namespace Wafi.BusReservationSystem.Domain.Entities
{
    public class RouteDroppingPoint : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid? RouteId { get; set; }
        public Guid? CityId { get; set; }
        public City? City { get; set; }
        public Route? Route { get; set; }
        public int DroppingPointsOrder { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public TimeSpan? DepartureTime { get; set; }
    }
}
