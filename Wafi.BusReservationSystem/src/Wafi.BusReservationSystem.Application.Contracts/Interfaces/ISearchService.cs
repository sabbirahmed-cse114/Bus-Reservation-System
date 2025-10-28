using Wafi.BusReservationSystem.Application.Contracts.DTOs;

namespace Wafi.BusReservationSystem.Application.Contracts.Interfaces
{
    public interface ISearchService
    {
        Task<List<AvailableBusDto>> SearchAvailableBusesAsync(string fromCityName, string toCityName, DateTime journeyDateUtc);
    }
}
