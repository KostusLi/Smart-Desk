using Application.Commands.CreateUser;
using Application.Commands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator _mediator) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUserAsync(RegisterUserCommand command)
        {
            Guid userId = await _mediator.Send(command);
            return Ok(userId);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUserAsync(LoginCommand command)
        {
            string token = await _mediator.Send(command);
            return Ok(token);
        }
    }
}
