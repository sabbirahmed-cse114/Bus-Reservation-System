using Wafi.BusReservationSystem.Domain.Entities;

namespace Wafi.BusReservationSystem.Domain.RepositoryContracts
{
    public interface IBusScheduleRepository : IRepositoryBase<BusSchedule, Guid>
    {
        Task<BusSchedule?> GetByIdAsync(Guid id);
        Task<IEnumerable<BusSchedule>> GetSchedulesByRouteAndDateAsync(Guid routeId, DateTime journeyDate);
        Task<IEnumerable<BusSchedule>> SearchSchedulesAsync(Guid fromCityId, Guid toCityId, DateTime journeyDate);
    }
}
