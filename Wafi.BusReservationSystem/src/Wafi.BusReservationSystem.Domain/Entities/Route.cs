
namespace Wafi.BusReservationSystem.Domain.Entities
{
    public class Route : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? BoardingPointId { get; set; }
        public Guid? DroppingPointId { get; set; }
        public ICollection<RouteDroppingPoint> DroppingPoints { get; set; } = new List<RouteDroppingPoint>();
        public ICollection<BusSchedule> BusSchedules { get; set; } = new List<BusSchedule>();
    }
}
