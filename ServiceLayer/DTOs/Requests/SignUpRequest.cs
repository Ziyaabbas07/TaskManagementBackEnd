using DataLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Requests
{
    public class SignUpRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public RoleMaster Role { get; set; }
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? PhoneNumber { get; set; }
        public int TeamId { get; set; }
    }
    public class SignUpRequestValidator : AbstractValidator<SignUpRequest>
    {
        public SignUpRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MinimumLength(3);
            RuleFor(x => x.LastName)
                .NotEmpty()
                .MinimumLength(3);
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(8).WithMessage("Password length must be atleast 8 characters")
                .MaximumLength(16).WithMessage("Password length must be maximum 16 characters")
                .Matches(@"[A-Z]+").WithMessage("Password must contain atleast one Upper Case letter ")
                .Matches(@"[a-z]+").WithMessage("Password must contain atleast one Lower Case letter ")
                .Matches(@"[0-9]+").WithMessage("Password must contain atleast one number ")
                .Matches(@"[\!\?\*\.\@]+").WithMessage("Password must contain atleast one (!,?,*,.,@) ");
            RuleFor(x => x.PhoneNumber)
                .NotNull().MinimumLength(10).MaximumLength(10);
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .NotNull()
                .Equal(x => x.Password)
                .When(x => !string.IsNullOrWhiteSpace(x.Password));
            RuleFor(x => x.Role)
                .NotNull();
        }
    }
}
