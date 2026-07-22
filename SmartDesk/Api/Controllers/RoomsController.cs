using Application.Commands.CreateRoom;
using Application.Queries;
using Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateRoomAsync(CreateRoomCommand command)
        {
            Guid roomId = await _mediator.Send(command);
            return Ok(roomId);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoomsAsync()
        {
            GetAllRoomsQuery query = new GetAllRoomsQuery();
            List<RoomDto> roomDtos = await _mediator.Send(query);
            return Ok(roomDtos);
        }
    }
}
