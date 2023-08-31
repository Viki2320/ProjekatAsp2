using AutoMapper;
using FluentValidation;
using ProjekatASP.Application;
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
    public class EfRateCommand : IRateCommand
    {

        private readonly ProjekatDbContext context;
        private readonly InsertRateValidator validator;
        private readonly IMapper mapper;
        private readonly IApplicationUser actor;


        public EfRateCommand(ProjekatDbContext context, InsertRateValidator validator, IMapper mapper, IApplicationUser actor)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
            this.actor = actor;
        }

        public int Id => 25;

        public string Name => "Rate restaurant";

        public void Execute(RateDto request)
        {
            validator.ValidateAndThrow(request);

            var rateMapped = mapper.Map<Rating>(request);
            rateMapped.UserId = actor.Id;

            context.Ratings.Add(rateMapped);

            context.SaveChanges();
        }
    }
}
