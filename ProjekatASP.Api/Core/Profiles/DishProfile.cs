using AutoMapper;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Domain;
using System.Linq;

namespace ProjekatASP.Api.Core.Profiles
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<CreateDishDto, Dish>()
              .ForMember(d => d.Name, opt => opt.MapFrom(cd => cd.Name))
              .ForMember(d => d.IsOnSale, opt => opt.MapFrom(cd => cd.OnSale))
              .ForMember(d => d.ImagePath, opt => opt.MapFrom(cd => cd.Image))
              .ForMember(d => d.Price, opt => opt.MapFrom(cd => cd))
              .ForMember(d => d.DishIngredients, opt => opt.MapFrom(cd => cd.IngredientIds.Select(i => new DishIngredient
               {
                   IngredientId = i
               })));

            CreateMap<CreateDishDto, Price>()
                .ForMember(d => d.NewPrice, opt => opt.MapFrom(dto => dto.NewPrice))
                .ForMember(d => d.OldPrice, opt => opt.MapFrom(dto => dto.OldPrice));


            CreateMap<Dish, DishDto>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(d => d.Name))
                .ForMember(dto => dto.CategoryId, opt => opt.MapFrom(d => d.CategoryId))
                .ForMember(dto => dto.CategoryName, opt => opt.MapFrom(d => d.Category.Name))
                //.ForMember(dto => dto.CategoryId, opt => opt.MapFrom(d => d.CategoryId))
                .ForMember(dto => dto.IsOnSale, opt => opt.MapFrom(d => d.IsOnSale))
                .ForMember(dto => dto.Image, opt => opt.MapFrom(d => d.ImagePath))
                .ForMember(dto => dto.OldPrice, opt => opt.MapFrom(d => d.Price.OldPrice))
                //.ForMember(dto => dto.NewPrice, opt => opt.MapFrom(d => (d.IsOnSale == true) ? (d.Price.NewPrice) : 0));
                .ForMember(dto => dto.NewPrice, opt => opt.MapFrom(d => d.Price.NewPrice));


            CreateMap<Dish, OneDishDto>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(d => d.Name))
                .ForMember(dto => dto.CategoryName, opt => opt.MapFrom(d => d.Category.Name))
                .ForMember(dto => dto.IngredientsName, opt => opt.MapFrom(d => d.DishIngredients.Select(di => di.Ingredient.Name)))
                .ForMember(dto => dto.IsOnSale, opt => opt.MapFrom(d => d.IsOnSale))
                .ForMember(dto => dto.Image, opt => opt.MapFrom(d => d.ImagePath))
                .ForMember(dto => dto.OldPrice, opt => opt.MapFrom(d => d.Price.OldPrice))
                //.ForMember(dto => dto.NewPrice, opt => opt.MapFrom(d => (d.IsOnSale == true) ? (d.Price.NewPrice) : 0));
                .ForMember(dto => dto.NewPrice, opt => opt.MapFrom(d => d.Price.NewPrice));


        }

    }
}
