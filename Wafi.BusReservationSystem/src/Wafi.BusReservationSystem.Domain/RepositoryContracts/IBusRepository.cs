using Wafi.BusReservationSystem.Domain.Entities;

namespace Wafi.BusReservationSystem.Domain.RepositoryContracts
{
    public interface IBusRepository : IRepositoryBase<Bus,Guid>
    {
        bool IsBusNameDuplicate(string Name, Guid? id = null);
    }
}
