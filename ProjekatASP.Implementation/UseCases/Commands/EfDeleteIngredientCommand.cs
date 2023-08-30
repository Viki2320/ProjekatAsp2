using ProjekatASP.Application.Exceptions;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Implementation.UseCases.Commands
{
    public class EfDeleteIngredientCommand : IDeleteIngredientCommand
    {
        private readonly ProjekatDbContext context;

        public EfDeleteIngredientCommand(ProjekatDbContext context)
        {
            this.context = context;
        }

        public int Id => 10;

        public string Name => "Delete ingredient Command";

        public void Execute(int request)
        {
            var cat = context.Ingredients.Find(request);

            if (cat == null)
            {
                throw new EntityNotFoundException(request, typeof(Ingredient));
            }

            cat.IsDeleted = true;
            context.SaveChanges();
        }
    }
}
