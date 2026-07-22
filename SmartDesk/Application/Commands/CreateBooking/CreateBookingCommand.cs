using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.CreateBooking
{
    public record CreateBookingCommand(Guid RoomId, string UserName, DateTime StartTime, DateTime EndTime) : IRequest<Guid>;
}
