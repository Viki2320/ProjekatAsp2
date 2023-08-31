using ProjekatASP.Application.Exceptions;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.DataAccess;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Implementation.UseCases.Commands
{
    public class EfChangeOrderStatusCommand : IChangeOrderStatusCommand
    {
        private readonly ProjekatDbContext context;

        public EfChangeOrderStatusCommand(ProjekatDbContext context)
        {
            this.context = context;
        }

        public int Id => 24;

        public string Name => "Change Order Status Command";

        public void Execute(ChangeOrderStatusDto request)
        {
            var order = context.Orders.Find(request.OrderId);
            if (order == null)
            {
                throw new EntityNotFoundException(request.OrderId, typeof(Order));
            }

            order.Status = request.OrderStatus;
            context.SaveChanges();
        }
    }
}
