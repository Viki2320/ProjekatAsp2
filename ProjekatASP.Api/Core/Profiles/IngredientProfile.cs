using AutoMapper;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Domain;

namespace ProjekatASP.Api.Core.Profiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<IngredientDto, Ingredient>(); 
            CreateMap<Ingredient, IngredientDto>();
        }
    }
}
