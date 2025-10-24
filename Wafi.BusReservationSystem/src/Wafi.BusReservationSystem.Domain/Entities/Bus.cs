
namespace Wafi.BusReservationSystem.Domain.Entities
{
    public class Bus: IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string BusName { get; set; }
        public int TotalSeats { get; set; }
    }
}
