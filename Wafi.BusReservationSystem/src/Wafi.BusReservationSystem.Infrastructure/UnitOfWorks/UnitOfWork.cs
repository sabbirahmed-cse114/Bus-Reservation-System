using Microsoft.EntityFrameworkCore;
using Wafi.BusReservationSystem.Domain;
using Wafi.BusReservationSystem.Domain.UtilityContracts;
using Wafi.BusReservationSystem.Infrastructure.Utilities;

namespace Wafi.BusReservationSystem.Infrastructure.UnitOfWorks
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        protected ISqlUtility SqlUtility { get; private set; }

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
            SqlUtility = new SqlUtility(_dbContext.Database.GetDbConnection());
        }
        public void Dispose() => _dbContext?.Dispose();
        public ValueTask DisposeAsync() => _dbContext.DisposeAsync();
        public void Save() => _dbContext?.SaveChanges();
        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}
