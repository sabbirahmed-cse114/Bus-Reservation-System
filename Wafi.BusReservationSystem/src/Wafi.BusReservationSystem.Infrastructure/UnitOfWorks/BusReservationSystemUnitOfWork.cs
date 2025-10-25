using Wafi.BusReservationSystem.Application;
using Wafi.BusReservationSystem.Domain.RepositoryContracts;
using Wafi.BusReservationSystem.Infrastructure.Data;

namespace Wafi.BusReservationSystem.Infrastructure.UnitOfWorks
{
    public class BusReservationSystemUnitOfWork : UnitOfWork, IBusReservationSystemUnitOfWork
    {
        public ICityRepository CityRepository { get; private set; }
        public IBusRepository BusRepository { get; private set; }

        public BusReservationSystemUnitOfWork(WafiDbContext context,
            ICityRepository cityRepository,
            IBusRepository busRepository) : base(context)
        {
            CityRepository = cityRepository;
            BusRepository = busRepository;
        }
    }
}
