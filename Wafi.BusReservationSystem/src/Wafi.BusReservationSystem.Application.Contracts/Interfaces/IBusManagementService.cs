using Wafi.BusReservationSystem.Domain.Entities;

namespace Wafi.BusReservationSystem.Application.Contracts.Interfaces
{
    public interface IBusManagementService
    {
        Task CreateBusAsync(Bus bus);
        Task<Bus> GetBusAsync(Guid id);
        Task<IList<Bus>> GetBusesAsync();
    }
}
