using Wafi.BusReservationSystem.Domain.Entities;

namespace Wafi.BusReservationSystem.Domain.RepositoryContracts
{
    public interface ISeatRepository : IRepositoryBase<Seat,Guid>
    {
        Task<IEnumerable<Seat>> GetSeatsByScheduleAsync(Guid busScheduleId);
    }
}
