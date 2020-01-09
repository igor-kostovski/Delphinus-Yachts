using AutoMapper;
using Delphinus_Yachts.Domain.Data.Entities;
using Delphinus_Yachts.Domain.Models;

namespace Delphinus_Yachts.Domain.Automapper.Profiles
{
    public class AvailabilityProfile : Profile
    {
        public AvailabilityProfile()
        {
            CreateMap<Booking, AvailabilityModel>()
                .ForMember(dest => dest.BookingId, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.BookingStart, opt => opt.MapFrom(x => x.StartDate))
                .ForMember(dest => dest.BookingEnd, opt => opt.MapFrom(x => x.EndDate))
                .ForMember(dest => dest.BookingStatus, opt => opt.MapFrom(x => x.StatusAsString));
        }
    }
}
