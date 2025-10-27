using Wafi.BusReservationSystem.Domain.Entities;

namespace Wafi.BusReservationSystem.Application.Contracts.Interfaces
{
    public interface ICityManagementService
    {
        Task CreateCityAsync(City city);
        IList<City> GetCities();
        City GetCity(Guid cityId);
    }
}
