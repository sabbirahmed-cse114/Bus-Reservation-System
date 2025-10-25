using Wafi.BusReservationSystem.Application.Contracts.Interfaces;
using Wafi.BusReservationSystem.Domain.Entities;

namespace Wafi.BusReservationSystem.Application.Services
{
    public class CityManagementService : ICityManagementService
    {
        private readonly IBusReservationSystemUnitOfWork _busReservationSystem;
        public CityManagementService(IBusReservationSystemUnitOfWork busReservationSystem)
        {
            _busReservationSystem = busReservationSystem;
        }
        public async Task CreateCityAsync(City city)
        {
            var isDuplicateTitle = _busReservationSystem.CityRepository.IsCityNameDuplicate(city.Name);

            if (!isDuplicateTitle)
            {
                await _busReservationSystem.CityRepository.AddAsync(city);
                await _busReservationSystem.SaveAsync();
            }
            else
            {
                throw new Exception("City name is duplicate");
            }
        }
        public async Task<IList<City>> GetCitiesAsync()
        {
            return await _busReservationSystem.CityRepository.GetOrderedCityAsync();
        }

        public async Task<City> GetCityAsync(Guid id)
        {
            return await _busReservationSystem.CityRepository.GetByIdAsync(id);
        }

    }
}
