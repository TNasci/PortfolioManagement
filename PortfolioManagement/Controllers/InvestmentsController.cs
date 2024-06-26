﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioManagement.Data;
using PortfolioManagement.Models;

namespace PortfolioManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentsController : ControllerBase
    {
        private readonly PortfolioManagementContext _context;

        public InvestmentsController(PortfolioManagementContext context)
        {
            _context = context;
        }

        [HttpPost("buy")]
        public async Task<ActionResult> BuyProduct(int clientId, int productId, decimal quantity)
        {
            var client = await _context.Clients.FindAsync(clientId);
            if (client == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            var product = await _context.FinancialProducts.FindAsync(productId);
            if (product == null)
            {
                return NotFound("Produto financeiro não encontrado.");
            }

            var investment = await _context.Investments
                .FirstOrDefaultAsync(i => i.ClientId == clientId && i.FinancialProductId == productId);

            if (investment == null)
            {
                investment = new Investment
                {
                    ClientId = clientId,
                    FinancialProductId = productId,
                    Quantity = quantity,
                    PurchaseDate = DateTime.Now,
                    TotalValue = quantity * product.Price
                };

                _context.Investments.Add(investment);
            }
            else
            {
                investment.Quantity += quantity;
                investment.TotalValue += quantity * product.Price;
            }

            await _context.SaveChangesAsync();

            return Ok("Compra realizada com sucesso.");
        }

        [HttpPost("sell")]
        public async Task<ActionResult> SellProduct(int clientId, int productId, decimal quantity)
        {
            var investment = await _context.Investments
                .FirstOrDefaultAsync(i => i.ClientId == clientId && i.FinancialProductId == productId);

            if (investment == null)
            {
                return NotFound("Investimento não encontrado.");
            }

            if (investment.Quantity < quantity)
            {
                return BadRequest("Quantidade de venda excede a quantidade do investimento.");
            }

            var product = await _context.FinancialProducts.FindAsync(productId);
            if (product == null)
            {
                return NotFound("Produto financeiro não encontrado.");
            }

            investment.Quantity -= quantity;
            investment.TotalValue -= quantity * product.Price;

            if (investment.Quantity == 0)
            {
                _context.Investments.Remove(investment);
            }

            await _context.SaveChangesAsync();

            return Ok("Venda realizada com sucesso.");
        }

        [HttpGet("statement")]
        public async Task<ActionResult<IEnumerable<object>>> GetClientInvestments([FromQuery] int clientId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var investments = await _context.Investments
                .Include(i => i.FinancialProduct)
                .Include(i => i.Client)
                .Where(i => i.ClientId == clientId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(i => new
                {
                    i.Id,
                    i.FinancialProductId,
                    FinancialProductName = i.FinancialProduct.Name,
                    FinancialProductType = i.FinancialProduct.Type,
                    i.Quantity,
                    i.PurchaseDate,
                    i.TotalValue,
                    ClientInfo = new
                    {
                        i.Client.CPF,
                        i.Client.Nome,
                        i.Client.Telefone
                    }
                })
                .ToListAsync();

            if (investments == null || !investments.Any())
            {
                return NotFound("Nenhum investimento encontrado para este cliente.");
            }

            return Ok(investments);
        }

        [HttpGet("statement/{clientId}/{productId}")]
        public async Task<ActionResult<object>> GetInvestmentStatement(int clientId, int productId)
        {
            var investment = await _context.Investments
                .Include(i => i.FinancialProduct)
                .Include(i => i.Client)
                .Where(i => i.ClientId == clientId && i.FinancialProductId == productId)
                .Select(i => new
                {
                    i.Id,
                    i.FinancialProductId,
                    FinancialProductName = i.FinancialProduct.Name,
                    FinancialProductType = i.FinancialProduct.Type,
                    i.Quantity,
                    i.PurchaseDate,
                    i.TotalValue,
                    ClientInfo = new
                    {
                        i.Client.CPF,
                        i.Client.Nome,
                        i.Client.Telefone
                    }
                })
                .FirstOrDefaultAsync();

            if (investment == null)
            {
                return NotFound("Investimento não encontrado.");
            }

            return Ok(investment);
        }
    }
}
