using Microsoft.AspNetCore.Mvc;
using Wafi.BusReservationSystem.Application.Contracts.DTOs;
using Wafi.BusReservationSystem.Application.Contracts.Interfaces;
using Wafi.BusReservationSystem.Domain;

namespace Wafi.BusReservationSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/[BookingController]")]
    public class BookingController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IBookingService _bookingService;
        private readonly IBusScheduleService _busScheduleService;

        public BookingController(IBookingService bookingService,
            IBusScheduleService busScheduleService)
        {
            _bookingService = bookingService;
            _busScheduleService = busScheduleService;
        }
        [HttpGet("seatplan/{busScheduleId:guid}")]
        public async Task<IActionResult> GetSeatPlanAsync(Guid busScheduleId)
        {
            var schedule = await _busScheduleService.GetBusScheduleByIdAsync(busScheduleId);
            if (schedule == null)
                return NotFound(new { message = "Bus schedule not found." });

            var seatPlan = new SeatPlanDto
            {
                BusScheduleId = schedule.Id,
                BusName = schedule.Bus?.Name ?? string.Empty,
                Seats = schedule.Seats
                    .OrderBy(s => s.SeatNumber)
                    .Select(s => new SeatInfoDto
                    {
                        SeatId = s.Id,
                        SeatNumber = s.SeatNumber,
                        Status = s.Status
                    })
                    .ToList()
            };

            return Ok(seatPlan);
        }
        [HttpPost]
        public async Task<IActionResult> BookSeatAsync([FromBody] BookSeatInputDto input)
        {
            if (input == null)
                return BadRequest("Invalid booking input.");

            var result = await _bookingService.BookSeatAsync(input);

            if (!result.IsSuccess)
                return Conflict(new { message = result.Message });

            return Ok(new
            {
                message = result.Message,
                ticketId = result.TicketId
            });
        }
    }
}
