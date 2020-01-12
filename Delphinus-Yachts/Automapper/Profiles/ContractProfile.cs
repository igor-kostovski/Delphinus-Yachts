using AutoMapper;
using Delphinus_Yachts.Domain.Models;
using Delphinus_Yachts.DTOs;

namespace Delphinus_Yachts.Automapper.Profiles
{
    public class ContractProfile : Profile
    {
        public ContractProfile()
        {
            CreateMap<ContractModel, ContractDTO>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(x => x.TypeAsString))
                .ReverseMap();
        }
    }
}