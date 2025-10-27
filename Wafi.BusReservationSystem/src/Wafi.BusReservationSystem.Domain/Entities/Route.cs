
namespace Wafi.BusReservationSystem.Domain.Entities
{
    public class Route : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? BoardingPointId { get; set; }
        public int Order {  get; set; }
        public double Distance { get; set; } = 0;
        public TimeSpan DepartureTime { get; set; }
        public City? BoardingPointCity { get; set; }
        public ICollection<RouteDroppingPoint> Stops { get; set; } = new List<RouteDroppingPoint>();
    }
}
