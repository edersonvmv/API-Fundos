using CaseItau.API.ViewModels;
using FluentValidation;

namespace CaseItau.API.Validators
{
    public class ParametroFundoViewModelValidator : AbstractValidator<ParametroFundoViewModel>
    {
        public ParametroFundoViewModelValidator()
        {
            RuleFor(x => x.Codigo)
                .NotEmpty().WithMessage("O campo Código é obrigatório")
                .MaximumLength(20).WithMessage("Código deve ter no máximo 20 caracteres");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo Nome é obrigatório")
                .MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres");

            RuleFor(x => x.Cnpj)
                .NotEmpty().WithMessage("O campo CNPJ é obrigatório")
                .Length(14).WithMessage("O CNPJ deve conter 14 digitos.")
                .Matches(@"^\d+$").WithMessage("O campo deve conter apenas números.");

            RuleFor(x => x.CodigoTipo)
                .NotEmpty().WithMessage("O campo CódigoTipo é obrigatório")
                .GreaterThan(0).WithMessage("O campo CódigoTipo deve ser maior que zero")
                .InclusiveBetween(1, 3).WithMessage("O CódigoTipo deve estar entre 1 e 3.");

            RuleFor(x => x.Patrimonio)
                .GreaterThanOrEqualTo(0).When(x => x.Patrimonio.HasValue).WithMessage("Patrimônio deve ser maior ou igual a zero");
        }
    }
}