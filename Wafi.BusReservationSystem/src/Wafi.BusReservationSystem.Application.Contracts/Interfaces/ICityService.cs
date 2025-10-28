using Wafi.BusReservationSystem.Domain.Entities;

namespace Wafi.BusReservationSystem.Application.Contracts.Interfaces
{
    public interface ICityService
    {
        Task CreateCityAsync(City city);
        IList<City> GetCities();
        City GetCity(Guid cityId);
        Task<City> GetByIdAsync(Guid cityId);
        Task<City?> GetByNameAsync(string name);
    }
}
