using Microsoft.EntityFrameworkCore;
using PortfolioManagement.Models;

namespace PortfolioManagement.Data
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options) { }

        public DbSet<FinancialProduct> FinancialProducts { get; set; }
        public DbSet<Investment> Investments { get; set; }
    }
}
