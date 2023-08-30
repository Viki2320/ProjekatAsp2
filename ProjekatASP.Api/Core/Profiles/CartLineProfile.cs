using AutoMapper;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Domain;

namespace ProjekatASP.Api.Core.Profiles
{
    public class CartLineProfile : Profile
    {
        public CartLineProfile()
        {
            CreateMap<Cart, CartLineDto>()
                .ForMember(dto => dto.Price, opt => opt.MapFrom(c => (c.Dish.IsOnSale ? c.Dish.Price.NewPrice : c.Dish.Price.OldPrice)))
                .ForMember(dto => dto.Quantity, opt => opt.MapFrom(c => c.Quantity))
                .ForMember(dto => dto.DishName, opt => opt.MapFrom(c => c.Dish.Name))
                .ForMember(dto => dto.Image, opt => opt.MapFrom(c => c.Dish.ImagePath));

            CreateMap<Cart, OrderLine>()
               .ForMember(ol => ol.Price, opt => opt.MapFrom(c => (c.Dish.IsOnSale ? c.Dish.Price.NewPrice : c.Dish.Price.OldPrice)))
               .ForMember(ol => ol.Quantity, opt => opt.MapFrom(c => c.Quantity))
               .ForMember(ol => ol.Name, opt => opt.MapFrom(c => c.Dish.Name))
               .ForMember(ol => ol.DishId, opt => opt.MapFrom(c => c.Dish.Id));
        }
    }
}
