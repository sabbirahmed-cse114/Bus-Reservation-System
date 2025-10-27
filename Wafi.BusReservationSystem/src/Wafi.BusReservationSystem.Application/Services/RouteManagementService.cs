using Wafi.BusReservationSystem.Application.Contracts.Interfaces;
using Wafi.BusReservationSystem.Domain;
using Wafi.BusReservationSystem.Domain.Entities;

namespace Wafi.BusReservationSystem.Application.Services
{
    public class RouteManagementService : IRouteManagementService
    {
        private readonly IBusReservationSystemUnitOfWork _busReservationSystem;
        public RouteManagementService(IBusReservationSystemUnitOfWork busReservationSystem)
        {
            _busReservationSystem = busReservationSystem;
        }

        public async Task CreateRouteAsync(Route route)
        {
            var isRouteDuplicate = _busReservationSystem.RouteRepository.IsDuplicateRoute(route.Name);
            var hasDroppingPointDuplicate = _busReservationSystem.RouteDroppingPointRepository.HasDroppingPointDuplicate(route.Stops.ToList());

            if(!isRouteDuplicate  && !hasDroppingPointDuplicate )
            {
                await _busReservationSystem.RouteRepository.AddAsync(route);
                await _busReservationSystem.SaveAsync();
            }

        }
    }
}
