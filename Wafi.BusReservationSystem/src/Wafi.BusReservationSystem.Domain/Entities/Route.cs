
namespace Wafi.BusReservationSystem.Domain.Entities
{
    public class Route : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid FromCityId { get; set; }
        public Guid ToCityId { get; set; }
        public City FromCity { get; set; }
        public City ToCity { get; set; }
        public ICollection<RouteDroppingPoint> Stops { get; set; } = new List<RouteDroppingPoint>();
    }
}
