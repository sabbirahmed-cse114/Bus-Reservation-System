
namespace Wafi.BusReservationSystem.Domain.Entities
{
    public class City : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
