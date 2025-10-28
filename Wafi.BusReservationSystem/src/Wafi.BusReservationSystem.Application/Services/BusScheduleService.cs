using Wafi.BusReservationSystem.Application.Contracts.Interfaces;
using Wafi.BusReservationSystem.Domain.Entities;

namespace Wafi.BusReservationSystem.Application.Services
{
    public class BusScheduleService : IBusScheduleService
    {
        private readonly IBusReservationSystemUnitOfWork _busReservationSystem;
        public BusScheduleService(IBusReservationSystemUnitOfWork busReservationSystem)
        {
            _busReservationSystem = busReservationSystem;
        }

        public async Task<BusSchedule?> GetBusScheduleByIdAsync(Guid busScheduleId)
        {
            return await _busReservationSystem.BusScheduleRepository.GetByIdAsync(busScheduleId);
        }
    }
}
