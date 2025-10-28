using Wafi.BusReservationSystem.Domain.Entities;

namespace Wafi.BusReservationSystem.Application.Contracts.Interfaces
{
    public interface IBusService
    {
        Task CreateBusAsync(Bus bus);
    }
}
