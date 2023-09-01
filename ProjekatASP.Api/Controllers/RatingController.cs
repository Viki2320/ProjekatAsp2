using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Application;
using ProjekatASP.Application.Searches;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Application.UseCases.Queries;

namespace ProjekatASP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RatingController : ControllerBase
    {
        private readonly UseCaseHandler handler;

        public RatingController(UseCaseHandler handler)
        {
            this.handler = handler;
        }

        [HttpPost]
        //[AllowAnonymous]
        public IActionResult Post([FromBody] RateDto dto, [FromServices] IRateCommand command)
        {
            handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] RateSearch search, [FromServices] IGetRateQuery query)
        {
            return Ok(handler.HandleQuery(query, search));
        }
    }
}
