using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wafi.BusReservationSystem.Domain.Entities;

namespace Wafi.BusReservationSystem.Domain.RepositoryContracts
{
    public interface IRouteRepository : IRepositoryBase<Route, Guid>
    {
        bool IsDuplicateRoute(string Name, Guid? Id = null);
    }
}
