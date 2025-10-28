using Wafi.BusReservationSystem.Application.Contracts.DTOs;
using Wafi.BusReservationSystem.Application.Contracts.Interfaces;
using Wafi.BusReservationSystem.Domain;
using Wafi.BusReservationSystem.Domain.Entities;

namespace Wafi.BusReservationSystem.Application.Services
{
    public class SearchService : ISearchService
    {
        private readonly IBusReservationSystemUnitOfWork _busReservationSystemUnitOfWork;
        public SearchService(IBusReservationSystemUnitOfWork busReservationSystemUnitOfWork)
        {
            _busReservationSystemUnitOfWork = busReservationSystemUnitOfWork;
        }
        public async Task<List<AvailableBusDto>> SearchAvailableBusesAsync(string from, string to, DateTime journeyDate)
        {
            if (string.IsNullOrWhiteSpace(from)) 
                throw new ArgumentException("fromCityName required");
            if (string.IsNullOrWhiteSpace(to)) 
                throw new ArgumentException("toCityName required");
            if (journeyDate == default) 
                throw new ArgumentException("journeyDateUtc required");

            var fromCity = await _busReservationSystemUnitOfWork.CityRepository.GetByNameAsync(from.Trim());
            var toCity = await _busReservationSystemUnitOfWork.CityRepository.GetByNameAsync(to.Trim());

            if (fromCity == null || toCity == null)
            {
                return new List<AvailableBusDto>();
            }

            var schedules = await _busReservationSystemUnitOfWork.BusScheduleRepository.SearchSchedulesAsync(fromCity.Id, toCity.Id, journeyDate);

            var result = new List<AvailableBusDto>();

            foreach (var schedule in schedules)
            {
                var orderedStops = schedule.Route?.DroppingPoints?.OrderBy(rs => rs.DroppingPointsOrder).ToList() ?? new List<RouteDroppingPoint>();

                var fromStop = orderedStops.FirstOrDefault(rs => rs.CityId == fromCity.Id);
                var toStop = orderedStops.FirstOrDefault(rs => rs.CityId == toCity.Id);

                if (fromStop == null || toStop == null) continue;
                if (fromStop.DroppingPointsOrder >= toStop.DroppingPointsOrder) continue;

                Func<Guid, RouteDroppingPoint?> routeStopLookup = id => orderedStops.FirstOrDefault(rs => rs.Id == id);

                int totalSeats = schedule.Seats?.Count() ?? 0;
                int seatsLeft = 0;

                var ticketsBySeat = schedule.Tickets?
                    .GroupBy(t => t.SeatId)
                    .ToDictionary(g => g.Key, g => g.AsEnumerable()) ?? new Dictionary<Guid, IEnumerable<Ticket>>();

                foreach (var seat in schedule.Seats)
                {
                    ticketsBySeat.TryGetValue(seat.Id, out var existingTicketsForSeat);
                    existingTicketsForSeat ??= Enumerable.Empty<Ticket>();

                    bool available = SeatAvailabilityService.IsSeatAvailableForSegment(
                        seat,
                        existingTicketsForSeat,
                        fromStop.DroppingPointsOrder,
                        toStop.DroppingPointsOrder,
                        routeStopLookup);

                    if (available)
                        seatsLeft++;
                }

                result.Add(new AvailableBusDto
                {
                    BusScheduleId = schedule.Id,
                    BusId = schedule.BusId,
                    BusName = schedule.Bus.Name,
                    CompanyName = schedule.Bus.CompanyName,
                    JourneyDate = schedule.JourneyDate,
                    DepartureTime = schedule.DepartureTime,
                    ArrivalTime = schedule.ArrivalTime,
                    Price = schedule.Price,
                    SeatsLeft = seatsLeft,
                    TotalSeats = totalSeats,
                    RouteId = schedule.RouteId,
                    RouteName = schedule.Route.Name,
                    BoardingPointId = fromCity.Id,
                    DroppingPointId = toCity.Id
                });
            }
            return result.OrderBy(r => r.DepartureTime).ToList();
        }
    }
}