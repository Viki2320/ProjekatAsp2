using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using ProjekatASP.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Implementation.UseCases.Commands
{
    public class EfUpdateDishCommand : IUpdateDishCommand
    {
        private readonly ProjekatDbContext context;
        private readonly UpdateDishValidator validator;

        public EfUpdateDishCommand(ProjekatDbContext context, UpdateDishValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int Id => 16;

        public string Name => "Update Dish Command";

        public void Execute(UpdateDishDto request)
        {
            validator.ValidateAndThrow(request);
        

            var dish = context.Dishes.Include(d => d.Price).Include(p =>p.DishIngredients).FirstOrDefault(x => x.Id == request.Id);

            try
            {
                var del = context.DishIngredients.Where(x => x.DishId == request.Id).ToList();
                context.DishIngredients.RemoveRange(del);
                foreach(var ingredientId in request.IngredientIds)
                {
                    
                    var dishIng = new DishIngredient
                    {
                        DishId = request.Id,
                        IngredientId = ingredientId
                    };
                    
                    context.DishIngredients.Add(dishIng);
                }
                //foreach(var i in request.IngredientIds)
                //{
                //    dish.DishIngredients.IngredientId = i;
                //}
                //dish.DishIngredients = request.IngredientIds;
                dish.CategoryId = request.CategoryId;
                dish.Name = request.Name;
                dish.IsOnSale = request.IsOnSale;
                dish.Price.NewPrice = request.NewPrice;
                dish.Price.OldPrice = request.OldPrice;
                if (!(string.IsNullOrEmpty(request.Image) || string.IsNullOrWhiteSpace(request.Image)))
                {
                    dish.ImagePath = request.Image;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
            
            context.SaveChanges();

        }
    }
}
