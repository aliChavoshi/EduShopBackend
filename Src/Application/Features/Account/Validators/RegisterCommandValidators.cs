using Application.Features.Account.Commands.RegisterUser;
using FluentValidation;

namespace Application.Features.Account.Validators;

public class RegisterCommandValidators : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidators()
    {
        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("لطفا شماره همراه خود را وارد کنید");
        RuleFor(x => x.DisplayName).NotEmpty().WithMessage("لطفا نام کاربری را وارد کنید");
        RuleFor(x => x.Password).NotEmpty().WithMessage("لطفا کلمه عبور را وارد کنید");
    }
}