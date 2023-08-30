using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Domain
{
    public class Order : Entity
    {
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public ValueOrderStatus Status { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; } = new HashSet<OrderLine>();


    }

    public enum ValueOrderStatus { Preparing, Delivered, Received, Canceled }
}
