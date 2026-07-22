using Application.Commands.CreateBooking;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Application.Handlers.BookingsHandlers
{
    public class CreateBookingCommandHandler(ISmartDeskDbContext _context, IExternalNotificationService externalNotificationService) : IRequestHandler<CreateBookingCommand, Guid>
    {
        public async Task<Guid> Handle(CreateBookingCommand command, CancellationToken cancellationToken)
        {
            Room? givenRoom = await _context.Rooms.AsNoTracking().FirstOrDefaultAsync(x => x.Id == command.RoomId, cancellationToken);
            if (givenRoom == null || !givenRoom.IsActive)
            {
                await SendMessageAndInvokeException("Такой комнаты не существует, либо отключена", cancellationToken);
            }

            bool isOverlapping = await _context.Bookings.Where(x => x.RoomId == command.RoomId).AnyAsync(x => (command.StartTime < x.EndTime) && (command.EndTime > x.StartTime));

            if (isOverlapping)
            {
                await SendMessageAndInvokeException("Комната уже занята в это время, выберите другое время или другую комнату", cancellationToken);
            }

            Booking booking = new Booking(command.RoomId, command.UserName, command.StartTime, command.EndTime);
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync(cancellationToken);

            await externalNotificationService.NotifyRoomCreatingAsync($"Успешно создана бронь для {command.UserName}", cancellationToken);

            return booking.Id;
        }

        public async Task SendMessageAndInvokeException(string message, CancellationToken cancellationToken)
        {
            await externalNotificationService.NotifyRoomCreatingAsync(message, cancellationToken);
            throw new BookingException(message);
        }
    }
}
