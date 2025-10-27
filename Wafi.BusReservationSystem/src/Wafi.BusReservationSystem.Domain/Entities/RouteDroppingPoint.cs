
namespace Wafi.BusReservationSystem.Domain.Entities
{
    public class RouteDroppingPoint : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid? RouteId { get; set; }
        public Guid? DroppingPointId { get; set; }
        public City? DroppingPointCity { get; set; }
        public Route? Route { get; set; }
        public int Order { get; set; }
        public double Distance { get; set; }
    }
}
