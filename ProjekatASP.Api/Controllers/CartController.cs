using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Application;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.Application.UseCases.DTO;
using ProjekatASP.Application.UseCases.Queries;

namespace ProjekatASP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly UseCaseHandler handler;

        public CartController(UseCaseHandler handler)
        {
            this.handler = handler;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] CartDto dto, [FromServices] IInsertIntoCartCommand command)
        {
            handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteDishFromCartCommand command)
        {
            handler.HandleCommand(command, id);
            return NoContent();
        }

        [HttpGet("{id}", Name = "GetCart")]
        public IActionResult Get(int id, [FromServices] IGetUserCartQuery query)
        {
            return Ok(handler.HandleQuery(query, id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CartDto dto, [FromServices] IUpdateQuantityCartCommand command)
        {
            dto.DishId = id;
            handler.HandleCommand(command, dto);
            return NoContent();
        }
    }
}
