using CaseItau.API.ViewModels;
using FluentValidation;

namespace CaseItau.API.Validators
{
    public class ParametroIdFundoViewModelValidator : AbstractValidator<ParametroIdFundoViewModel>
    {
        public ParametroIdFundoViewModelValidator()
        {
            RuleFor(x => x.Codigo)
                .NotEmpty().WithMessage("O campo Código é obrigatório")
                .MaximumLength(20).WithMessage("Código deve ter no máximo 20 caracteres");
        }
    }
}
