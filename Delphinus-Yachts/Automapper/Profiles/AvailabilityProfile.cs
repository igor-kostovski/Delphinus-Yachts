using AutoMapper;
using Delphinus_Yachts.Domain.Models;
using Delphinus_Yachts.DTOs;

namespace Delphinus_Yachts.Automapper.Profiles
{
    public class AvailabilityProfile : Profile
    {
        public AvailabilityProfile()
        {
            CreateMap<AvailabilityModel, AvailabilityDTO>();
        }
    }
}