using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public record GetAllRoomsQuery() : IRequest<List<RoomDto>>;

}
