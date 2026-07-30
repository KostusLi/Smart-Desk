using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.CreateUser
{
    public record RegisterUserCommand(string UserName, string Password, string Email) : IRequest<Guid>;
}
