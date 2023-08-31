using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.Application.Email
{
    public interface IEmailSender
    {
        void Send(SendMailDto dto);
    }

    public class SendMailDto
    {
        public string SendTo { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
