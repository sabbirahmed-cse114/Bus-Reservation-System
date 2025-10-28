using Wafi.BusReservationSystem.Domain.Entities;
using Wafi.BusReservationSystem.Domain.RepositoryContracts;
using Wafi.BusReservationSystem.Infrastructure.Data;

namespace Wafi.BusReservationSystem.Infrastructure.Repositories
{
    public class TicketRepository : Repository<Ticket, Guid>, ITicketRepository
    {
        public TicketRepository(WafiDbContext context) : base(context) 
        { 
        }
    }
}
