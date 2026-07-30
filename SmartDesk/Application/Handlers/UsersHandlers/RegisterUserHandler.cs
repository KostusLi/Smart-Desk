using Application.Commands.CreateUser;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers.UsersHandlers
{
    public class RegisterUserHandler(ISmartDeskDbContext _context, IPasswordHasher _hasher) : IRequestHandler<RegisterUserCommand, Guid>
    {
        public async Task<Guid> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            User user = new User();
            string passwordHashing = await _hasher.Hasher(command.Password);
            user.UserName = command.UserName;
            user.PasswordHash = passwordHashing;
            user.Email = command.Email;
            user.Role = Role.User;
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            return user.Id;
        }
    }
}
