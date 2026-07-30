using Application.Commands.LoginUser;
using Application.Exceptions;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers.UsersHandlers
{
    public class LoginHandler(ISmartDeskDbContext _context, IPasswordHasher passwordHasher, IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, string>
    {
        public async Task<string> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Where(x => x.Email == command.Email).FirstOrDefaultAsync();
            if(user==null)
            {
                throw new LoginException("Пользователя не существует");
            }

            if(!await passwordHasher.Verify(command.Password, user.PasswordHash))
            {
                throw new LoginException("Не верный пароль");
            }

            string token = await jwtProvider.GenerateToken(user);
            return token;
        }

    }
}
