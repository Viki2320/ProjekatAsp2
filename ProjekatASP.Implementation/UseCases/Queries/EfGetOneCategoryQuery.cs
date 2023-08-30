using AutoMapper;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Application.UseCases.Queries;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Implementation.UseCases.Queries
{
    public class EfGetOneCategoryQuery : IGetOneCategoryQuery
    {

        private readonly ProjekatDbContext context;
        private readonly IMapper mapper;
        public int Id => 14;

        public string Name => "Get One Category";



        public EfGetOneCategoryQuery(ProjekatDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public CategoryDto Execute(int search)
        {
            var category = context.Categories.FirstOrDefault(x => x.Id == search);
            if (category == null)
            {
                throw new EntityNotFoundException(search, typeof(Category));
            }
            var categoryDto = mapper.Map<CategoryDto>(category);
            return categoryDto;
        }
    }
}
