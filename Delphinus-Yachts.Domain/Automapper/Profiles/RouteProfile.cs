using AutoMapper;
using Delphinus_Yachts.Domain.Data.Entities;
using Delphinus_Yachts.Domain.Models;

namespace Delphinus_Yachts.Domain.Automapper.Profiles
{
    public class RouteProfile : Profile
    {
        public RouteProfile()
        {
            CreateMap<Route, RouteModel>().ReverseMap();
        }
    }
}
