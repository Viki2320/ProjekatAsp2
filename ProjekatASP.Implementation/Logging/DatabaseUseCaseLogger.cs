using Newtonsoft.Json;
using ProjekatASP.Application;
using ProjekatASP.Application.UseCases;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Implementation.Logging
{
    public class DatabaseUseCaseLogger : IUseCaseLogger
    {
        private readonly ProjekatDbContext _context;

        public DatabaseUseCaseLogger(ProjekatDbContext context)
        {
            _context = context;
        }
        public void Log(IUseCase useCase, IApplicationUser actor, object useCaseData)
        {
            _context.UseCaseLogs.Add(new UseCaseLog
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(useCaseData),
                Date = DateTime.UtcNow,
                UseCaseName = useCase.Name
            });

            _context.SaveChanges();
        }
    }
}
