using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wafi.BusReservationSystem.Application.Contracts.Interfaces;
using Wafi.BusReservationSystem.Domain.Entities;
using Wafi.BusReservationSystem.Web.Models;

namespace Wafi.BusReservationSystem.Web.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityManagementService _cityManagementService;
        private readonly ILogger<CityController> _logger;
        private readonly IMapper _mapper;
        public CityController(ICityManagementService cityManagementService, 
            ILogger<CityController> logger,
            IMapper mapper)
        {
            _cityManagementService = cityManagementService;
            _logger = logger;
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
        public async Task<IActionResult> Create(CityCreateModel model)
        {
            var city = _mapper.Map<City>(model);
            city.Id = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                try
                {
                    await _cityManagementService.CreateCityAsync(city);
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
