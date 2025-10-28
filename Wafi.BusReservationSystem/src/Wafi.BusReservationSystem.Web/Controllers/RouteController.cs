using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wafi.BusReservationSystem.Application.Contracts.Interfaces;
using Wafi.BusReservationSystem.Domain.Entities;
using Wafi.BusReservationSystem.Infrastructure.Utility;
using Wafi.BusReservationSystem.Web.Models.RouteModels;

namespace Wafi.BusReservationSystem.Web.Controllers
{
    public class RouteController : Controller
    {
        private readonly ILogger<RouteController> _logger;
        private readonly IRouteService _routeManagementService;
        private readonly ICityService _cityManagementService;
        private readonly IMapper _mapper;

        public RouteController(ILogger<RouteController> logger, 
            IRouteService routeManagementService, 
            ICityService cityManagementService,
            IMapper mapper)
        {
            _logger = logger;
            _routeManagementService = routeManagementService;
            _cityManagementService = cityManagementService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var model = new RouteCreateModel();
            var cities = _cityManagementService.GetCities();
            model.SetBoardingPointsValues(cities);

            ViewBag.AllCities = cities.Select(c => new { value = c.Id, text = c.Name }).ToList();

            return View(model);
        }

        //[HttpPost, ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(RouteCreateModel model)
        //{
        //    var cities = _cityManagementService.GetCities();
        //    model.SetBoardingPointsValues(cities);

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            int cnt = 1;
        //            var route = _mapper.Map<Domain.Entities.Route>(model);
        //            route.Id = Guid.NewGuid();
        //            route.BoardingPointCity = _cityManagementService.GetCity((Guid)model.BoardingPointId);

        //                foreach (var dpModel in model.DroppingPoints)
        //                {
        //                    var droppingPoint = new RouteDroppingPoint
        //                    {
        //                        Id = Guid.NewGuid(),
        //                        RouteId = route.Id,
        //                        DroppingPointId = dpModel.DroppingPointId,
        //                        Distance = dpModel.Distance,
        //                        Order = cnt++
        //                    };
        //                    route.Stops.Add(droppingPoint);
        //                route.Distance += dpModel.Distance;
        //                }
        //            route.TotalStops = cnt - 1;
        //            await _routeManagementService.CreateRouteAsync(route);
        //            TempData["Success"] = "Route created successfully!";
        //            return RedirectToAction("Index");
        //        }
        //        catch (Exception ex)
        //        {
        //            _logger.LogError(ex, "Error creating route");
        //            TempData["Error"] = "Failed to create route.";
        //            return View(model);
        //        }
        //    }
        //    return View(model);
        //}
    }
}
