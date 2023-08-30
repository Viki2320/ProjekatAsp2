using AutoMapper;
using FluentValidation;
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
    public class EfCreateCategoryCommand : ICreateCategoryCommand
    {
        private readonly ProjekatDbContext context;
        private readonly CreateCategoryValidator validator;
        private readonly IMapper mapper;

        public EfCreateCategoryCommand(ProjekatDbContext context, CreateCategoryValidator validator, IMapper mapper)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
        }

        public int Id => 2;

        public string Name => "Create Category Command";

        public void Execute(CategoryDto request)
        {
            validator.ValidateAndThrow(request);

            var categoryMapped = mapper.Map<Category>(request);

            context.Categories.Add(categoryMapped);
            context.SaveChanges();
        }
    }
}
