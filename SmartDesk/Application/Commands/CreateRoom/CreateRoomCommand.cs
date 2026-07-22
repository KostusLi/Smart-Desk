using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.CreateRoom
{
    public record CreateRoomCommand(string Name, int Capacity) : IRequest<Guid>;
}
