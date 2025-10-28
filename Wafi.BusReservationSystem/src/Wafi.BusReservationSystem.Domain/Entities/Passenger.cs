
namespace Wafi.BusReservationSystem.Domain.Entities
{
    public class Passenger : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
