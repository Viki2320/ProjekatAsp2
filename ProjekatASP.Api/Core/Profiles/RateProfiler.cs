using AutoMapper;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Domain;

namespace ProjekatASP.Api.Core.Profiles
{
    public class RateProfile : Profile
    {
        public RateProfile()
        {
            CreateMap<RateDto, Rating>()
                .ForMember(d => d.RatingValue, opt => opt.MapFrom(dto => dto.RateValue));

            CreateMap<Rating, RateDto>()
                .ForMember(dto => dto.RateValue, opt => opt.MapFrom(d => d.RatingValue));


        }
    }
}
