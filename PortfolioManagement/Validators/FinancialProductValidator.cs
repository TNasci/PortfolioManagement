using FluentValidation;
using PortfolioManagement.Models;

namespace PortfolioManagement.Validators
{
    public class FinancialProductValidator : AbstractValidator<FinancialProduct>
    {
        public FinancialProductValidator()
        {
            RuleFor(fp => fp.Name)
                .NotEmpty().WithMessage("O nome do produto é obrigatório.")
                .Length(2, 100).WithMessage("O nome do produto deve ter entre 2 e 100 caracteres.");

            RuleFor(fp => fp.Type)
                .NotEmpty().WithMessage("O tipo do produto é obrigatório.")
                .Length(2, 50).WithMessage("O tipo do produto deve ter entre 2 e 50 caracteres.");

            RuleFor(fp => fp.Price)
                .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");

            RuleFor(fp => fp.MaturityDate)
                .GreaterThan(DateTime.Now).WithMessage("A data de vencimento deve ser no futuro.");
        }
    }
}
