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
    public class EfDeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly ProjekatDbContext context;

        public EfDeleteCategoryCommand(ProjekatDbContext context)
        {
            this.context = context;
        }

        public int Id => 9;

        public string Name => "Delete Category Command";

        public void Execute(int request)
        {
            var cat = context.Categories.Find(request);

            if (cat == null)
            {
                throw new EntityNotFoundException(request, typeof(Category));
            }

            cat.IsDeleted = true;
            context.SaveChanges();
        }
    }
}
