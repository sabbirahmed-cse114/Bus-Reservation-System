using Wafi.BusReservationSystem.Domain.Entities;

namespace Wafi.BusReservationSystem.Domain.RepositoryContracts
{
    public interface ICityRepository : IRepositoryBase<City,Guid>
    {
        bool IsCityNameDuplicate(string Name, Guid? id = null);
        Task<IList<City>> GetOrderedCityAsync();
    }
}
