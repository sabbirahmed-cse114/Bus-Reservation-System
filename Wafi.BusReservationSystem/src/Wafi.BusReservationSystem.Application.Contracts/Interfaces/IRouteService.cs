using Wafi.BusReservationSystem.Domain.Entities;

namespace Wafi.BusReservationSystem.Application.Contracts.Interfaces
{
    public interface IRouteService
    {
        Task CreateRouteAsync(Route route);
    }
}
