using ProjekatASP.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Application.Exceptions
{
    public class UnauthorizedUseCaseException : Exception
    {
        public UnauthorizedUseCaseException(IUseCase useCase, IApplicationUser actor)
            : base($"Actor with an id of {actor.Id} - {actor.Identity} tried to execute {useCase.Name}.")
        {

        }
    }
}
