using Wafi.BusReservationSystem.Application.Contracts.DTOs;
using Wafi.BusReservationSystem.Application.Contracts.Interfaces;
using Wafi.BusReservationSystem.Domain;
using Wafi.BusReservationSystem.Domain.Entities;
using Wafi.BusReservationSystem.Domain.Enums;

namespace Wafi.BusReservationSystem.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBusReservationSystemUnitOfWork _busReservationSystem;
        public BookingService(IBusReservationSystemUnitOfWork busReservationSystem)
        {
            _busReservationSystem = busReservationSystem;
        }
        public async Task<BookSeatResultDto> BookSeatAsync(BookSeatInputDto input, CancellationToken cancellationToken = default)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            var schedule = await _busReservationSystem.BusScheduleRepository.GetByIdAsync(input.BusScheduleId);
            if (schedule == null)
                return new BookSeatResultDto { IsSuccess = false, Message = "Bus schedule not found." };

            var routeStops = schedule.Route?.DroppingPoints?.OrderBy(rs => rs.DroppingPointsOrder).ToList() ?? [];
            var fromStop = routeStops.FirstOrDefault(x => x.Id == input.BoardingStopId);
            var toStop = routeStops.FirstOrDefault(x => x.Id == input.DroppingStopId);

            if (fromStop == null || toStop == null)
                return new BookSeatResultDto { IsSuccess = false, Message = "Invalid boarding/dropping point." };

            if (fromStop.DroppingPointsOrder >= toStop.DroppingPointsOrder)
                return new BookSeatResultDto { IsSuccess = false, Message = "Invalid journey segment." };

            var seat = schedule.Seats.FirstOrDefault(s => s.Id == input.SeatId);
            if (seat == null)
                return new BookSeatResultDto { IsSuccess = false, Message = "Seat not found." };

            var ticketsForSeat = schedule.Tickets.Where(t => t.SeatId == seat.Id);
            Func<Guid, RouteDroppingPoint?> lookup = id => routeStops.FirstOrDefault(rs => rs.Id == id);

            bool available = SeatAvailabilityService.IsSeatAvailableForSegment(
                seat, ticketsForSeat, fromStop.DroppingPointsOrder, toStop.DroppingPointsOrder, lookup);

            if (!available)
                return new BookSeatResultDto { IsSuccess = false, Message = "Seat already booked for this segment." };

            var passenger = new Passenger
            {
                Name = input.PassengerName,
                MobileNumber = input.PassengerMobile            };

            var ticket = new Ticket
            {
                BusScheduleId = schedule.Id,
                SeatId = seat.Id,
                Passenger = passenger,
                BoardingPointId = input.BoardingStopId,
                DroppingPointId = input.DroppingStopId,
                Status = TicketStatus.Confirmed,
                Fare = schedule.Price,
                BookingTime = DateTime.UtcNow
            };

            seat.Status = SeatStatus.Booked;

            try
            {
                await _busReservationSystem.TicketRepository.AddAsync(ticket);
                await _busReservationSystem.SeatRepository.EditAsync(seat);
                await _busReservationSystem.SaveAsync();
                return new BookSeatResultDto
                {
                    IsSuccess = true,
                    Message = $"Seat {seat.SeatNumber} booked successfully!",
                    TicketId = ticket.Id
                };
            }
            catch (Exception ex)
            {
                return new BookSeatResultDto
                {
                    IsSuccess = false,
                    Message = $"Booking failed: {ex.Message}"
                };
            }
        }
    }
}
