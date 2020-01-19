using AutoMapper;
using Delphinus_Yachts.Domain.Models;
using Delphinus_Yachts.DTOs;

namespace Delphinus_Yachts.Automapper.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<LocationModel, LocationDTO>().ReverseMap();
        }
    }
}