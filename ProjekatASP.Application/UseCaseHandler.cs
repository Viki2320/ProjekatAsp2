using ProjekatASP.Application.Exceptions;
using ProjekatASP.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Application
{
    public class UseCaseHandler
    {
        private readonly IApplicationUser _actor;
        private readonly IUseCaseLogger _logger;

        public UseCaseHandler(IApplicationUser actor, IUseCaseLogger logger)
        {
            _actor = actor;
            _logger = logger;
        }

        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest request)//request su podaci neophodni da bi se komanda izvrsila
        {
            _logger.Log(command, _actor, request);
            //Console.WriteLine($"{DateTime.Now}: {_actor.Identity} is trying to execute {command.Name} using data: " + $"{JsonConvert.SerializeObject(request)}");

            if (!_actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseException(command, _actor);
            }

            command.Execute(request);

        }

        public TResult HandleQuery<TRequest, TResult>(IQuery<TRequest, TResult> query, TRequest search)
        {
            _logger.Log(query, _actor, search);

            if (!_actor.AllowedUseCases.Contains(query.Id))
            {
                throw new UnauthorizedUseCaseException(query, _actor);
            }

            return query.Execute(search);
        }
    }
}
