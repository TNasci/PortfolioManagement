using FluentValidation;
using PortfolioManagement.Models;

namespace PortfolioManagement.Validators
{
    public class InvestmentBuyAndSellValidator : AbstractValidator<Investment>
    {
        public InvestmentBuyAndSellValidator()
        {
            RuleFor(i => i.ClientId)
                .GreaterThan(0).WithMessage("O ID do cliente deve ser maior que zero.");

            RuleFor(i => i.FinancialProductId)
                .GreaterThan(0).WithMessage("O ID do produto financeiro deve ser maior que zero.");

            RuleFor(i => i.Quantity)
                .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.");

            RuleFor(i => i.TotalValue)
                .GreaterThan(0).WithMessage("O valor total deve ser maior que zero.");

            RuleFor(i => i.ClientId)
                .GreaterThan(0).WithMessage("O ID do cliente deve ser maior que zero.");

            RuleFor(i => i.FinancialProductId)
                .GreaterThan(0).WithMessage("O ID do produto financeiro deve ser maior que zero.");

            RuleFor(i => i.Quantity)
                .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.");
        }
    }
}
