using Microsoft.AspNetCore.Mvc;
using PortfolioManagement.Data;
using PortfolioManagement.Models;

namespace PortfolioManagement.Controllers
{
    public class MassFinancialProducts : Controller
    {
        private readonly PortfolioContext _context;
        public MassFinancialProducts(PortfolioContext context)
        {
            _context = context;    
        }

        [HttpPost("mass")]
        public async Task<ActionResult> AddMassFinancialProducts()
        {
            var products = new List<FinancialProduct>();

            for (int i = 1; i <= 1000; i++)
            {
                products.Add(new FinancialProduct
                {
                    Name = $"Produto {i}",
                    Type = GetRandomType(),
                    Price = GetRandomPrice(),
                    MaturityDate = DateTime.Now.AddMonths(GetRandomMaturityMonths())
                });
            }

            _context.FinancialProducts.AddRange(products);
            await _context.SaveChangesAsync();

            return Ok("1000 produtos adicionados com sucesso!");
        }

        #region Private Method
        private string GetRandomType()
        {
            string[] types = { "Tipo A", "Tipo B", "Tipo C" };
            return types[new Random().Next(types.Length)];
        }

        private decimal GetRandomPrice()
        {
            return new Random().Next(1000, 10000);
        }

        private int GetRandomMaturityMonths()
        {
            return new Random().Next(6, 120);
        }
        #endregion
    }
}
