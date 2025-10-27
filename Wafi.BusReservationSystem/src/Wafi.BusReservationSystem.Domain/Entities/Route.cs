
namespace Wafi.BusReservationSystem.Domain.Entities
{
    public class Route : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? BoardingPointId { get; set; }
        public int TotalStops {  get; set; }
        public double Distance { get; set; } = 0;
        public City? BoardingPointCity { get; set; }
        public ICollection<RouteDroppingPoint> Stops { get; set; } = new List<RouteDroppingPoint>();
    }
}
