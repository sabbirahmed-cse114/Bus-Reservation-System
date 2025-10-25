using Wafi.BusReservationSystem.Domain.Entities;

namespace Wafi.BusReservationSystem.Application.Contracts.Interfaces
{
    public interface ICityManagementService
    {
        Task CreateCityAsync(City city);
        Task<City> GetCityAsync(Guid id);
        Task<IList<City>> GetCitiesAsync();
    }
}
