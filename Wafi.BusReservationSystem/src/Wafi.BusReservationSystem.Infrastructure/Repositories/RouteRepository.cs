using Microsoft.EntityFrameworkCore;
using Wafi.BusReservationSystem.Domain.Entities;
using Wafi.BusReservationSystem.Domain.RepositoryContracts;
using Wafi.BusReservationSystem.Infrastructure.Data;

namespace Wafi.BusReservationSystem.Infrastructure.Repositories
{
    public class RouteRepository : Repository<Route,Guid>, IRouteRepository
    {
        public RouteRepository(WafiDbContext context) : base(context) 
        { 
        }

        public bool IsDuplicateRoute(string name, Guid? Id = null)
        {
            if (Id.HasValue)
            {
                return GetCount(x => !x.Id.Equals(Id.Value) && x.Name.Equals(name)) > 0;
            }
            else
            {
                return GetCount(x => x.Name.Equals(name)) > 0;
            }
        }
    }
}
