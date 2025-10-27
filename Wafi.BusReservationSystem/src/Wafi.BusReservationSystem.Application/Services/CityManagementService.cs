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
            var isDuplicateCity = _busReservationSystem.CityRepository.IsCityNameDuplicate(city.Name);

            if (!isDuplicateCity)
            {
                await _busReservationSystem.CityRepository.AddAsync(city);
                await _busReservationSystem.SaveAsync();
            }
            else
            {
                throw new Exception("City name is duplicate");
            }
        }

        public IList<City> GetCities()
        {
            return _busReservationSystem.CityRepository.GetAll();
        }

        public City GetCity(Guid cityId)
        {
            return _busReservationSystem.CityRepository.GetById(cityId);
        }
    }
}
