using Wafi.BusReservationSystem.Domain.Entities;
using Wafi.BusReservationSystem.Domain.RepositoryContracts;
using Wafi.BusReservationSystem.Infrastructure.Data;

namespace Wafi.BusReservationSystem.Infrastructure.Repositories
{
    public class RouteDroppingPointRepository : Repository<RouteDroppingPoint,Guid>, IRouteDroppingPointRepository
    {
        public RouteDroppingPointRepository(WafiDbContext context) : base(context) 
        { 
        }

        public bool HasDroppingPointDuplicate(IList<RouteDroppingPoint> droppingPoints)
        {
            if (droppingPoints == null || droppingPoints.Count == 0)
                return false;
            var cityIds = droppingPoints.Select(dp => dp.DroppingPointId).ToList();
            foreach (var cityId in cityIds)
            {
                int count = droppingPoints.Count(dp => dp.DroppingPointId.Equals(cityId));
                if (count > 1)
                    return true;
            }
            return false;
        }
    }
}
