using Wafi.BusReservationSystem.Domain.Entities;
using Wafi.BusReservationSystem.Domain.Enums;

namespace Wafi.BusReservationSystem.Domain
{
    public static class SeatAvailabilityService
    {
        public static bool IsSeatAvailableForSegment(Seat seat, IEnumerable<Ticket> existingTickets, 
            int requestedBoardOrder, 
            int requestedDropOrder, 
            Func<Guid, RouteDroppingPoint?> routeDroppingPoints)
        {
            if (seat.Status == SeatStatus.Sold) return false;

            foreach (var t in existingTickets)
            {
                var existingBoardStop = routeDroppingPoints(t.BoardingPointId);
                var existingDropStop = routeDroppingPoints(t.DroppingPointId);
                if (existingBoardStop == null || existingDropStop == null) continue;

                int existingBoard = existingBoardStop.DroppingPointsOrder;
                int existingDrop = existingDropStop.DroppingPointsOrder;

                bool overlap = requestedBoardOrder < existingDrop && existingBoard < requestedDropOrder;
                if (overlap && t.Status == Domain.Enums.TicketStatus.Confirmed)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
