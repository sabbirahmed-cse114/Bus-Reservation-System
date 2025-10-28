using Microsoft.EntityFrameworkCore;
using Wafi.BusReservationSystem.Domain.Entities;
using Wafi.BusReservationSystem.Domain.RepositoryContracts;
using Wafi.BusReservationSystem.Infrastructure.Data;

namespace Wafi.BusReservationSystem.Infrastructure.Repositories
{
    public class BusScheduleRepository : Repository<BusSchedule,Guid>, IBusScheduleRepository
    {
        public BusScheduleRepository(WafiDbContext context) : base(context) 
        {
            
        }
        public async Task<BusSchedule?> GetByIdAsync(Guid id)
        {
            return await SingleOrDefaultAsync(x => x, x => x.Id == id);
        }

        public async Task<IEnumerable<BusSchedule>> GetSchedulesByRouteAndDateAsync(Guid routeId, DateTime journeyDate)
        {
            return await GetAsync(x => x.RouteId == routeId && x.JourneyDate.Date == journeyDate.Date, include: null);
        }

        public async Task<IEnumerable<BusSchedule>> SearchSchedulesAsync(Guid fromCityId, Guid toCityId, DateTime journeyDate)
        {
            return await GetAsync(x => x.Route.BoardingPointId == fromCityId && x.Route.DroppingPointId == toCityId &&
                     x.JourneyDate.Date == journeyDate.Date, include: q => q.Include(s => s.Route).Include(s => s.Bus));
        }
    }
}
