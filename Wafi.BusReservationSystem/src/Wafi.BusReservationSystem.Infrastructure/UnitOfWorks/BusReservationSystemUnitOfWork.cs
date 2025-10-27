using Wafi.BusReservationSystem.Application;
using Wafi.BusReservationSystem.Domain.RepositoryContracts;
using Wafi.BusReservationSystem.Infrastructure.Data;

namespace Wafi.BusReservationSystem.Infrastructure.UnitOfWorks
{
    public class BusReservationSystemUnitOfWork : UnitOfWork, IBusReservationSystemUnitOfWork
    {
        public ICityRepository CityRepository { get; private set; }
        public IBusRepository BusRepository { get; private set; }
        public IRouteRepository RouteRepository { get; private set; }
        public IRouteDroppingPointRepository RouteDroppingPointRepository { get; private set; }

        public BusReservationSystemUnitOfWork(WafiDbContext context,
            ICityRepository cityRepository,
            IBusRepository busRepository,
            IRouteRepository routeRepository,
            IRouteDroppingPointRepository routeDroppingPointRepository) : base(context)
        {
            CityRepository = cityRepository;
            BusRepository = busRepository;
            RouteRepository = routeRepository;
            RouteDroppingPointRepository = routeDroppingPointRepository;
        }
    }
}
