using AutoMapper;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Domain;

namespace ProjekatASP.Api.Core.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<CartDto, Cart>()
             .ForMember(c => c.DishId, opt => opt.MapFrom(dto => dto.DishId))
             .ForMember(c => c.Quantity, opt => opt.MapFrom(dto => dto.Quantity));
        }
    }
}
