using AutoMapper;
using FluentValidation;
using ProjekatASP.Application.Email;
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
    public class EfRegisterUserCommand : IRegisterUserCommand
    {

        private readonly ProjekatDbContext _context;
        private readonly RegisterUserValidator _validator;
        private readonly IMapper _mapper;
        
        public int Id => 1;

        public string Name => "User registration";

        public EfRegisterUserCommand(ProjekatDbContext context, RegisterUserValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
           
        }

        public void Execute(RegisterUserDto request)
        {
            //var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            _validator.ValidateAndThrow(request);
            //throw new NotImplementedException();

            User newUser = _mapper.Map<User>(request);

            _context.Users.Add(newUser);

            _context.SaveChanges();

           
        }
    }
}
