using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.CreateBooking
{
    public record CreateBookingCommand(Guid RoomId, DateTime StartTime, DateTime EndTime) : IRequest<Guid>;
}
