using ProjekatASP.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Application
{
    public interface IUseCaseLogger
    {
        void Log(IUseCase useCase, IApplicationUser actor, object useCaseData);
    }
}
