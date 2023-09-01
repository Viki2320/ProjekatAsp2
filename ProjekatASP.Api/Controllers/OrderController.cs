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
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly UseCaseHandler handler;

        public OrderController(UseCaseHandler handler)
        {
            this.handler = handler;
        }

        [HttpPost]
        public IActionResult Post([FromBody] OrderDto dto, [FromServices] ICreateOrderCommand command)
        {
            handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult Get(int id, [FromServices] IGetOrderQuery query)
        {
            return Ok(handler.HandleQuery(query, id));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ChangeOrderStatusDto dto, [FromServices] IChangeOrderStatusCommand command)
        {
            dto.OrderId = id;
            handler.HandleCommand(command, dto);
            return NoContent();
        }
    }
}
