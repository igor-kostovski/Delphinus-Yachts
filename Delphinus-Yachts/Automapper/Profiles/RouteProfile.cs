using AutoMapper;
using Delphinus_Yachts.Domain.Models;
using Delphinus_Yachts.DTOs;

namespace Delphinus_Yachts.Automapper.Profiles
{
    public class RouteProfile : Profile
    {
        public RouteProfile()
        {
            CreateMap<RouteModel, RouteDTO>().ReverseMap();
        }
    }
}