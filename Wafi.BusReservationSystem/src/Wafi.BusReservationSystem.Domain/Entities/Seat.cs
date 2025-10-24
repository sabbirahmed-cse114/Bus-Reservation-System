

namespace Wafi.BusReservationSystem.Domain.Entities
{
    public class Seat : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid BusScheduleId { get; set; }
        public string SeatNumber { get; set; }
        public int Row { get; set; }
        public SeatStatus Status { get; set; }
    }
}
