using Wafi.BusReservationSystem.Application.Contracts.DTOs;

namespace Wafi.BusReservationSystem.Application.Contracts.Interfaces
{
    public interface IBookingService
    {
        Task<BookSeatResultDto> BookSeatAsync(BookSeatInputDto input, CancellationToken cancellationToken = default);
    }
}
