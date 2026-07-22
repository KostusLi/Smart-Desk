using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.CreateRoom
{
    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Capacity).NotEmpty().GreaterThan(0);
        }
    }
}
