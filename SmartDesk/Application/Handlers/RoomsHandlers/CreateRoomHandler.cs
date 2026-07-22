using Application.Commands.CreateRoom;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers.RoomsHandlers
{
    public class CreateRoomHandler(ISmartDeskDbContext _сontext, IExternalNotificationService _externalNotificationService) : IRequestHandler<CreateRoomCommand, Guid>
    {
        public async Task<Guid> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            Room room = new Room();
            room.Name = request.Name;
            room.Capacity = request.Capacity;
            room.IsActive = true;
            _сontext.Rooms.Add(room);
            await _сontext.SaveChangesAsync(cancellationToken);
            await _externalNotificationService.NotifyRoomCreatingAsync(room.Name, cancellationToken);
            return room.Id;
        }
    }
}
