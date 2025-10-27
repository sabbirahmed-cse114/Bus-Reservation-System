using Wafi.BusReservationSystem.Domain;
using Wafi.BusReservationSystem.Domain.RepositoryContracts;

namespace Wafi.BusReservationSystem.Application
{
    public interface IBusReservationSystemUnitOfWork : IUnitOfWork
    {
        public ICityRepository CityRepository { get; }
        public IBusRepository BusRepository { get; }
        public IRouteRepository RouteRepository { get; }
        public IRouteDroppingPointRepository RouteDroppingPointRepository { get; }
    }
}
