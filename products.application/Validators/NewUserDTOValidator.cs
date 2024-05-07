using FluentValidation;
using products.application.DTO;
using Products.Application.DTO;

namespace products.application.Validators
{
    public class NewUserDTOValidator : AbstractValidator<NewUserDTO>
    {
        public NewUserDTOValidator(){
            RuleFor(x => x.Name)
                .MinimumLength(6)
                .MaximumLength(100)
                .NotEmpty()
                .WithMessage("Nome deve conter mais de 6 e menos que 100 caracteres!");
            
            RuleFor(x => x.Email)
                .MinimumLength(6)
                .MaximumLength(100)
                .NotEmpty()
                .WithMessage("Email deve conter mais de 6 e menos que 100 caracteres!");
            
            RuleFor(x => x.Gender)
                .MinimumLength(1)
                .MaximumLength(1)
                .NotEmpty()
                .WithMessage("Genero deve conter ao menos 1 caractere");

            // RuleFor(x => x.CPFCNPJ)
            //     .NotEmpty().WithMessage("O CPF ou CNPJ é obrigatório.")
            //     .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$")
            //     .WithMessage("Formato de CPF inválido.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("O campo é obrigatório.")
                .Matches(@"^(?=.*[a-zA-Z])(?=.*[@#$%^&+=]).+$")
                .WithMessage("O campo deve conter pelo menos um caractere especial e uma letra maiúscula ou minúscula.");
        }
    }
}