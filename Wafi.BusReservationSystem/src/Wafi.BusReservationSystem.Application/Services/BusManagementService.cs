using Wafi.BusReservationSystem.Application.Contracts.Interfaces;
using Wafi.BusReservationSystem.Domain.Entities;

namespace Wafi.BusReservationSystem.Application.Services
{
    public class BusManagementService : IBusManagementService
    {
        private readonly IBusReservationSystemUnitOfWork _busReservationSystem;
        public BusManagementService(IBusReservationSystemUnitOfWork busReservationSystem)
        {
            _busReservationSystem = busReservationSystem;
        }
        public async Task CreateBusAsync(Bus bus)
        {
            var isBusNameDuplicate = _busReservationSystem.BusRepository.IsBusNameDuplicate(bus.BusName);

            if (!isBusNameDuplicate)
            {
                await _busReservationSystem.BusRepository.AddAsync(bus);
                await _busReservationSystem.SaveAsync();
            }
            else
            {
                throw new Exception("Bus name is duplicate");
            }
        }
    }
}
