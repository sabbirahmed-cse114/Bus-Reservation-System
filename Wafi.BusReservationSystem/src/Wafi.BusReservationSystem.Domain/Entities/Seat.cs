using Wafi.BusReservationSystem.Domain.Enums;

namespace Wafi.BusReservationSystem.Domain.Entities
{
    public class Seat : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid BusScheduleId { get; set; }
        public string SeatNumber { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public SeatStatus Status { get; set; } = SeatStatus.Available;
        public BusSchedule? BusSchedule { get; set; }
        public Ticket? Ticket { get; set; }
    }
}
