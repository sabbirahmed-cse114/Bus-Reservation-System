using Wafi.BusReservationSystem.Domain.Entities;
using Wafi.BusReservationSystem.Domain.Enums;
using Wafi.BusReservationSystem.Domain.RepositoryContracts;
using Wafi.BusReservationSystem.Infrastructure.Data;

namespace Wafi.BusReservationSystem.Infrastructure.Repositories
{
    public class SeatRepository : Repository<Seat, Guid>, ISeatRepository
    {
        public SeatRepository(WafiDbContext context) : base(context) 
        { 
        }
        public async Task<IEnumerable<Seat>> GetSeatsByScheduleAsync(Guid busScheduleId)
        {
            return await GetAsync(x => x.BusScheduleId == busScheduleId && x.Status == SeatStatus.Available, include: null);
        }
    }
}
