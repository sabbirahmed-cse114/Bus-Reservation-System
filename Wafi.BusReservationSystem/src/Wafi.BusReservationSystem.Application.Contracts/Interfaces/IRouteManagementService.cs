using Wafi.BusReservationSystem.Domain.Entities;

namespace Wafi.BusReservationSystem.Application.Contracts.Interfaces
{
    public interface IRouteManagementService
    {
        Task CreateRouteAsync(Route route);
    }
}
