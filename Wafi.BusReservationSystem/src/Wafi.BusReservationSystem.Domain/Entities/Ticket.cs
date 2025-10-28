using Wafi.BusReservationSystem.Domain.Enums;

namespace Wafi.BusReservationSystem.Domain.Entities
{
    public class Ticket : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid BusScheduleId { get; set; }
        public Guid PassengerId { get; set; }
        public Guid SeatId { get; set; }

        public Guid BoardingPointId { get; set; }
        public Guid DroppingPointId { get; set; }
        public DateTime BookingTime { get; set; }
        public TicketStatus Status { get; set; }
        public decimal Fare {  get; set; }

        public BusSchedule? BusSchedule { get; set; }
        public Passenger? Passenger { get; set; }
        public Seat? Seat { get; set; }
    }
}
