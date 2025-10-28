using Microsoft.AspNetCore.Mvc;
using Wafi.BusReservationSystem.Application.Contracts.Interfaces;

namespace Wafi.BusReservationSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/[BusController]")]
    public class BusController : Controller
    {
        private readonly ISearchService _searchService;
        public BusController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchAsync([FromQuery] string from, [FromQuery] string to, [FromQuery] DateTime date, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to))
                return BadRequest("From and To city names are required.");

            if (date == default)
                return BadRequest("Invalid journey date.");

            var buses = await _searchService.SearchAvailableBusesAsync(from, to, date);

            if (buses == null || buses.Count == 0)
                return NotFound(new { message = "No buses found for the selected route and date." });

            return Ok(buses);
        }
    }
}
