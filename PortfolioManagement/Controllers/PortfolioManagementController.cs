using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioManagement.Data;
using PortfolioManagement.Models;

namespace PortfolioManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialProductsController : ControllerBase
    {
        private readonly PortfolioContext _context;

        public FinancialProductsController(PortfolioContext context)
        {
            _context = context;
        }

        // GET: api/FinancialProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinancialProduct>>> GetFinancialProducts([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var products = await _context.FinancialProducts
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return products;
        }

        // GET: api/FinancialProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinancialProduct>> GetFinancialProduct(int id)
        {
            var financialProduct = await _context.FinancialProducts.FindAsync(id);

            if (financialProduct == null)
            {
                return NotFound();
            }

            return financialProduct;
        }

        // POST: api/FinancialProducts
        [HttpPost]
        public async Task<ActionResult<FinancialProduct>> PostFinancialProduct(FinancialProduct financialProduct)
        {
            _context.FinancialProducts.Add(financialProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinancialProduct", new { id = financialProduct.Id }, financialProduct);
        }

        // PUT: api/FinancialProducts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinancialProduct(int id, FinancialProduct financialProduct)
        {
            if (id != financialProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(financialProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinancialProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/FinancialProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinancialProduct(int id)
        {
            var financialProduct = await _context.FinancialProducts.FindAsync(id);
            if (financialProduct == null)
            {
                return NotFound();
            }

            _context.FinancialProducts.Remove(financialProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FinancialProductExists(int id)
        {
            return _context.FinancialProducts.Any(e => e.Id == id);
        }
    }
}
