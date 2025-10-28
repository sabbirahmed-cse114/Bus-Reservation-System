
namespace Wafi.BusReservationSystem.Application.Contracts.DTOs
{
    public class BookSeatInputDto
    {
        public Guid BusScheduleId { get; set; }
        public Guid SeatId { get; set; }
        public Guid BoardingStopId { get; set; }
        public Guid DroppingStopId { get; set; }

        public string PassengerName { get; set; }
        public string PassengerMobile { get; set; }
    }
}
