using Application.Interfaces;
using Application.Queries;
using Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers.RoomsHandlers
{
    public class GetAllRoomsHandler(ISmartDeskDbContext _context) : IRequestHandler<GetAllRoomsQuery, List<RoomDto>>
    {
        public async Task<List<RoomDto>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Rooms.Select(r => new RoomDto(r.Id, r.Name, r.Capacity, r.IsActive)).AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
