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
    public class CategoriesController : ControllerBase
    {

        private readonly IApplicationUser actor;
        private readonly UseCaseHandler handler;

        public CategoriesController(IApplicationUser actor, UseCaseHandler handler)
        {
            this.actor = actor;
            this.handler = handler;
        }


        // GET: api/Categories
        [HttpGet]
        public IActionResult Get([FromQuery] CategorySearch search, [FromServices] IGetCategoriesQuery query)
        {
            return Ok(handler.HandleQuery(query, search));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CategoryDto dto, [FromServices] ICreateCategoryCommand command)
        {
            handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCategoryCommand command)
        {
            handler.HandleCommand(command, id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCategoryDto dto, [FromServices] IUpdateCategoryCommand command)
        {
            dto.Id = id;
            handler.HandleCommand(command, dto);
            return NoContent();
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult Get(int id, [FromServices] IGetOneCategoryQuery query)
        {
            return Ok(handler.HandleQuery(query, id));
        }




    }
}
