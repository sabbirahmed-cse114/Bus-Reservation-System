using AutoMapper;
using Wafi.BusReservationSystem.Domain.Entities;
using Wafi.BusReservationSystem.Web.Models;
using Wafi.BusReservationSystem.Web.Models.Bus;

namespace Wafi.BusReservationSystem.Web
{
    public class WebProfile : Profile
    {
        public WebProfile() 
        
        { 
            CreateMap<CityCreateModel, City>().ReverseMap();
            CreateMap<BusCreateModel, Bus>().ReverseMap();
        }
    }
}
