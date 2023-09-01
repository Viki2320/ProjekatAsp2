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
    public class IngredientsController : ControllerBase
    {
        private readonly IApplicationUser actor;
        private readonly UseCaseHandler handler;

        public IngredientsController(IApplicationUser actor, UseCaseHandler handler)
        {
            this.actor = actor;
            this.handler = handler;
        }

        [HttpPost]
        public IActionResult Post([FromBody] IngredientDto dto, [FromServices] ICreateIngredientCommand command)
        {
            handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] IngredientSearch search, [FromServices] IGetIngredientsQuery query)
        {
            return Ok(handler.HandleQuery(query, search));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteIngredientCommand command)
        {
            handler.HandleCommand(command, id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateIngredientDto dto, [FromServices] IUpdateIngredientCommand command)
        {
            dto.Id = id;
            handler.HandleCommand(command, dto);
            return NoContent();
        }

        [HttpGet("{id}", Name = "GetIngredient")]
        [AllowAnonymous]
        public IActionResult Get(int id, [FromServices] IGetOneIngredientQuery query)
        {
            return Ok(handler.HandleQuery(query, id));
        }
    }
}
