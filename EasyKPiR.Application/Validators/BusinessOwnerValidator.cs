using EasyKPiR.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyKPiR.Application.Validators
    {
    public class BusinessOwnerValidator : AbstractValidator<BusinessOwnerDto>
        {
        public BusinessOwnerValidator()
            {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Imię i nazwisko lub nazwa firmy jest wymagane.")
                .MaximumLength(100);

            RuleFor(x => x.NIP)
                .NotEmpty().WithMessage("NIP jest wymagany.")
                .Length(10).WithMessage("NIP powinien zawierać dokładnie 10 cyfr.")
                .Matches(@"^\d{10}$").WithMessage("NIP powinien zawierać tylko cyfry.");

            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrWhiteSpace(x.Email))
                .WithMessage("Nieprawidłowy adres e-mail.");

            RuleFor(x => x.VatRate)
                .InclusiveBetween(0, 1).WithMessage("Stawka VAT powinna być między 0 a 1.");

            RuleFor(x => x.IncomeTaxRate)
                .InclusiveBetween(0, 1).WithMessage("Stawka podatku dochodowego powinna być między 0 a 1.");

            RuleFor(x => x.ZUSAmount)
                .GreaterThanOrEqualTo(0).WithMessage("Składka ZUS nie może być ujemna.");
            }
        }
    }
