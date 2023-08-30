using ProjekatASP.Application;
using System.Collections.Generic;

namespace ProjekatASP.Api.Core
{
    public class AnonymousActor : IApplicationUser
    {
        public int Id => 0;

        public string Identity => "Anonymous User";

        public IEnumerable<int> AllowedUseCases => new List<int> { 1, 5, 6, 15, 14, 8, 13 };
    }
}
