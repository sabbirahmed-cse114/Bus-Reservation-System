using Wafi.BusReservationSystem.Domain.Entities;
using Wafi.BusReservationSystem.Domain.RepositoryContracts;
using Wafi.BusReservationSystem.Infrastructure.Data;

namespace Wafi.BusReservationSystem.Infrastructure.Repositories
{
    public class CityRepository : Repository<City, Guid>, ICityRepository
    {
        public CityRepository(WafiDbContext context) : base(context) 
        { 
        } 
        public bool IsCityNameDuplicate(string name, Guid? id = null)
        {
            if (id.HasValue)
            {
                return GetCount(x => !x.Id.Equals(id.Value) && x.Name.Equals(name)) > 0;
            }
            else
            {
                return GetCount(x => x.Name.Equals(name)) > 0;
            }
        }

        public async Task<IList<City>> GetOrderedCityAsync()
        {
            return await GetAsync(null, x => x.OrderBy(y => y.Name), null, true);
        }
    }
}
