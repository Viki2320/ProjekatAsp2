using AutoMapper;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Domain;
using System.Linq;

namespace ProjekatASP.Api.Core.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, Order>()
            .ForMember(o => o.OrderDate, opt => opt.MapFrom(dto => dto.OrderDate))
            .ForMember(o => o.Address, opt => opt.MapFrom(dto => dto.Address))
            .ForMember(o => o.UserId, opt => opt.MapFrom(dto => dto.UserId))
            .ForMember(o => o.OrderLines, opt => opt.MapFrom(dto => dto.OrderLines.Select(c => new OrderLine
            {
                Price = (c.Dish.IsOnSale) ? (c.Dish.Price.NewPrice) : (c.Dish.Price.OldPrice),
                Quantity = c.Quantity,
                Name = c.Dish.Name,
                DishId = c.Dish.Id
            })));

            CreateMap<Order, GetOrderDto>()
           .ForMember(ro => ro.OrderDate, opt => opt.MapFrom(o => o.OrderDate))
           .ForMember(ro => ro.Address, opt => opt.MapFrom(o => o.Address))
           .ForMember(o => o.UserIdentity, opt => opt.MapFrom(dto => dto.User.Username))
           .ForMember(o => o.GetOrderLines, opt => opt.MapFrom(dto => dto.OrderLines.Select(ol => new GetOrderLineDto
           {
               Id = ol.Id,
               Price = (ol.Dish.IsOnSale) ? (ol.Dish.Price.NewPrice) : (ol.Dish.Price.OldPrice),
               Quantity = ol.Quantity,
               ArticleName = ol.Dish.Name
           })));
        }
    }
}
