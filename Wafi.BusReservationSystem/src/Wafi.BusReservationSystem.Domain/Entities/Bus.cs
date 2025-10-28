using Wafi.BusReservationSystem.Domain.Enums;

namespace Wafi.BusReservationSystem.Domain.Entities
{
    public class Bus: IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public int TotalSeats { get; set; }
        public BusType BusType { get; set; }
        public ICollection<BusSchedule> Schedules { get; set; } = new List<BusSchedule>();
    }
}
