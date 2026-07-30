using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.CreateBooking
{
    public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
    {
        public CreateBookingCommandValidator()
        {
            RuleFor(x => x.EndTime).NotEmpty().GreaterThan(x => x.StartTime);
            RuleFor(x => x.StartTime).NotEmpty().GreaterThan(DateTime.UtcNow);
        }
    }
}
