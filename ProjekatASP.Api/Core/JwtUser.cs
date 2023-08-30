using ProjekatASP.Application;
using System.Collections.Generic;

namespace ProjekatASP.Api.Core
{
    public class JwtUser : IApplicationUser
    {
        public int Id { get; set; }

        public string Identity { get; set; }

        public IEnumerable<int> AllowedUseCases { get; set; } = new List<int>();
        public string Username { get; set; }
    }
}
