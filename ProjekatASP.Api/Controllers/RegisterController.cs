using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Application;
using ProjekatASP.Application.UseCases.Commands;
using ProjekatASP.Application.UseCases.DTO;

namespace ProjekatASP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private readonly UseCaseHandler _handler;

        public RegisterController(UseCaseHandler handler)
        {
            _handler = handler;
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] RegisterUserDto request, [FromServices] IRegisterUserCommand command)
        {
            _handler.HandleCommand(command, request);

            return StatusCode(StatusCodes.Status201Created);
        }

    }
}
