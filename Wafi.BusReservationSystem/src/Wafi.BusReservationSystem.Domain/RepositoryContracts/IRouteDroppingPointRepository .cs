using Wafi.BusReservationSystem.Domain.Entities;

namespace Wafi.BusReservationSystem.Domain.RepositoryContracts
{
    public interface IRouteDroppingPointRepository : IRepositoryBase<RouteDroppingPoint, Guid>
    {
        bool HasDroppingPointDuplicate(IList<RouteDroppingPoint> droppingPoints);
    }
}
