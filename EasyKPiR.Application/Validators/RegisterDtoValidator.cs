using EasyKPiR.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyKPiR.Application.Validators
    {

    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
        {
        public RegisterDtoValidator()
            {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-mail jest wymagany.")
                .EmailAddress().WithMessage("Nieprawidłowy format adresu e-mail.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Hasło jest wymagane.")
                .MinimumLength(8).WithMessage("Hasło musi mieć co najmniej 8 znaków.")
                .Matches("[A-Z]").WithMessage("Hasło musi zawierać co najmniej jedną wielką literę.")
                .Matches("[a-z]").WithMessage("Hasło musi zawierać co najmniej jedną małą literę.")
                .Matches("[0-9]").WithMessage("Hasło musi zawierać co najmniej jedną cyfrę.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Hasło musi zawierać co najmniej jeden znak specjalny.");

            }
        }
    }
