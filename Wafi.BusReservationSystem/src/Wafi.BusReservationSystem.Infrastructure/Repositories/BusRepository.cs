using Wafi.BusReservationSystem.Domain.Entities;
using Wafi.BusReservationSystem.Domain.RepositoryContracts;
using Wafi.BusReservationSystem.Infrastructure.Data;

namespace Wafi.BusReservationSystem.Infrastructure.Repositories
{
    public class BusRepository: Repository<Bus, Guid>, IBusRepository
    {
        public BusRepository(WafiDbContext context) : base(context)
        {
        }
        public bool IsBusNameDuplicate(string name, Guid? id = null)
        {
            if (id.HasValue)
            {
                return GetCount(x => !x.Id.Equals(id.Value) && x.BusName.Equals(name)) > 0;
            }
            else
            {
                return GetCount(x => x.BusName.Equals(name)) > 0;
            }
        }

        public async Task<IList<Bus>> GetOrderedBusAsync()
        {
            return await GetAsync(null, x => x.OrderBy(y => y.BusName), null, true);
        }
    }
}
