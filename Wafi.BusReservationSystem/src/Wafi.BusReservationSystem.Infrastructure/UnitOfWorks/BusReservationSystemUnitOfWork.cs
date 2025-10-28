using Wafi.BusReservationSystem.Application;
using Wafi.BusReservationSystem.Domain.RepositoryContracts;
using Wafi.BusReservationSystem.Infrastructure.Data;

namespace Wafi.BusReservationSystem.Infrastructure.UnitOfWorks
{
    public class BusReservationSystemUnitOfWork : UnitOfWork, IBusReservationSystemUnitOfWork
    {
        public ICityRepository CityRepository { get; private set; }
        public IBusRepository BusRepository { get; private set; }
        public IBusScheduleRepository BusScheduleRepository { get; private set; }
        public IRouteRepository RouteRepository { get; private set; }
        public IRouteDroppingPointRepository RouteDroppingPointRepository { get; private set; }
        public ISeatRepository SeatRepository { get; private set; }
        public ITicketRepository TicketRepository { get; private set; }

        public BusReservationSystemUnitOfWork(WafiDbContext context,
            ICityRepository cityRepository,
            IBusRepository busRepository,
            IBusScheduleRepository busScheduleRepository,
            IRouteRepository routeRepository,
            IRouteDroppingPointRepository routeDroppingPointRepository,
            ISeatRepository seatRepository,
            ITicketRepository ticketRepository) : base(context)
        {
            CityRepository = cityRepository;
            BusRepository = busRepository;
            BusScheduleRepository = busScheduleRepository;
            RouteRepository = routeRepository;
            RouteDroppingPointRepository = routeDroppingPointRepository;
            SeatRepository = seatRepository;
            TicketRepository = ticketRepository;
        }
    }
}
