using AutoMapper;
using BusinessLogic.Models;
using DataAccess.Models;
using DTOS;

namespace BusinessLogic.Profiles
{
    public class AvailabilityProfile : Profile
    {
        public AvailabilityProfile()
        {
            CreateMap<AvailabilityBussinessModel, Availability>()
                .ForMember(dest => dest.Quest, opt => opt.MapFrom(src => src.Quest));
            CreateMap<AvailabilityDto, Availability>();
        }
    }
}