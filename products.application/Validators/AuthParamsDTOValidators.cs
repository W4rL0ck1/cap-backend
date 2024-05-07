using FluentValidation;
using Products.Application.DTO;

namespace products.application.Validators
{
    public class AuthParamsDTOValidators : AbstractValidator<AuthParamsDTO>
    {
        public AuthParamsDTOValidators(){
            RuleFor(x => x.Email)
                .MinimumLength(6)
                .MaximumLength(100)
                .NotEmpty()
                .WithMessage("Email deve conter mais de 6 e menos que 100 caracteres!");
        }
    }
}