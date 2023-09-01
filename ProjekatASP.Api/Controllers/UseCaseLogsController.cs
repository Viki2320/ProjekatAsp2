using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Application;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Application.UseCases.Queries;

namespace ProjekatASP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UseCaseLogsController : ControllerBase
    {
        private readonly UseCaseHandler handler;

        public UseCaseLogsController(UseCaseHandler handler)
        {
            this.handler = handler;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] AuditLogsSearchDto search, [FromServices] IAuditLogsQuery query)
        {
            return Ok(handler.HandleQuery(query, search));
        }
    }
}
