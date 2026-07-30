using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.LoginUser
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Пароль не может быть пустым")
                .MinimumLength(8).WithMessage("В пароле должно быть минимум 8 символов")
                .Matches(@"[A-Z]").WithMessage("Пароль должен содержать заглавные буквы")
                .Matches(@"[0-9]").WithMessage("Пароль должен содержать цифры")
                .Matches(@"[a-z]").WithMessage("Пароль должен содержать строчные буквы")
                .Matches(@"[^a-zA-Z0-9]").WithMessage("Пароль должен содержать специальные символы");
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}
