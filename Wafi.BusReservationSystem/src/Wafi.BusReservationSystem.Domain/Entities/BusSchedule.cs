namespace Wafi.BusReservationSystem.Domain.Entities
{
    public class BusSchedule : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid RouteId { get; set; }
        public Guid BusId { get; set; }
        public DateTime JourneyDate { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public int Price { get; set; }
        public Route? Route { get; set; }
        public Bus? Bus { get; set; }

        public ICollection<Seat> Seats { get; set; } = new List<Seat>();
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
