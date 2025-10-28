using Wafi.BusReservationSystem.Domain.Entities;

namespace Wafi.BusReservationSystem.Domain.RepositoryContracts
{
    public interface ITicketRepository : IRepositoryBase<Ticket, Guid>
    {
    }
}
