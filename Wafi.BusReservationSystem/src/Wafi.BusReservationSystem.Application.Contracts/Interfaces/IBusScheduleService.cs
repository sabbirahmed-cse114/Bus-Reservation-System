
using Wafi.BusReservationSystem.Domain.Entities;

namespace Wafi.BusReservationSystem.Application.Contracts.Interfaces
{
    public interface IBusScheduleService
    {
        Task<BusSchedule?> GetBusScheduleByIdAsync(Guid busScheduleId);
    }
}
