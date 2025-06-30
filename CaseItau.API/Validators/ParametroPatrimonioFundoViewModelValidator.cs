using CaseItau.API.ViewModels;
using FluentValidation;

namespace CaseItau.API.Validators
{
    public class ParametroPatrimonioFundoViewModelValidator : AbstractValidator<ParametroPatrimonioFundoViewModel>
    {
        public ParametroPatrimonioFundoViewModelValidator()
        {
            RuleFor(x => x.Codigo)
                .NotEmpty().WithMessage("O campo Código é obrigatório")
                .MaximumLength(20).WithMessage("Código deve ter no máximo 20 caracteres");

            RuleFor(x => x.Patrimonio)
                .NotEmpty().WithMessage("O campo Patrimônio é obrigatório")
                .GreaterThanOrEqualTo(0).WithMessage("Patrimônio deve ser maior ou igual a zero");
        }
    }
}
