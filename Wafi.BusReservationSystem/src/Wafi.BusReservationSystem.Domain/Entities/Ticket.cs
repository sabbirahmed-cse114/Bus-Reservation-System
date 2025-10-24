

namespace Wafi.BusReservationSystem.Domain.Entities
{
    public class Ticket : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid BusScheduleId { get; set; }
        public string SeatNumber { get; set; }
        public Guid PassengerId { get; set; }
        public Passenger Passenger { get; set; }
        public DateTime BookingTime { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
