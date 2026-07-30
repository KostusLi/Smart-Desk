using Application.Commands.CreateBooking;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateBookingAsync(CreateBookingCommand command)
        {
            Guid bookingId = await mediator.Send(command);
            return Ok(bookingId);
        }
    }
}
