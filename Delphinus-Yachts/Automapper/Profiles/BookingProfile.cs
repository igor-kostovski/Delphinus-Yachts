using AutoMapper;
using Delphinus_Yachts.Domain.Models;
using Delphinus_Yachts.DTOs;

namespace Delphinus_Yachts.Automapper.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingModel, BookingDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(x => x.StatusAsString))
                .ReverseMap()
                .ForMember(dest => dest.Contract, opt => opt.Ignore());
        }
    }
}