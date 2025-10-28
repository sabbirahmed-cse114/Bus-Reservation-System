using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wafi.BusReservationSystem.Application.Contracts.Interfaces;
using Wafi.BusReservationSystem.Application.Services;
using Wafi.BusReservationSystem.Domain.Entities;
using Wafi.BusReservationSystem.Web.Models;
using Wafi.BusReservationSystem.Web.Models.Bus;

namespace Wafi.BusReservationSystem.Web.Controllers
{
    public class BusController : Controller
    {
        private readonly ILogger<BusController> _logger;
        private readonly IBusService _busManagementService;
        private readonly IMapper _mapper;

        public BusController(ILogger<BusController> logger, 
            IBusService busManagementService, 
            IMapper mapper)
        {
            _logger = logger;
            _busManagementService = busManagementService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BusCreateModel model)
        {
            var bus = _mapper.Map<Bus>(model);
            bus.Id = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                try
                {
                    await _busManagementService.CreateBusAsync(bus);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}
