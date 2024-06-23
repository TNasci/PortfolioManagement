using Microsoft.EntityFrameworkCore;
using PortfolioManagement.Models;

namespace PortfolioManagement.Data
{
    public class PortfolioManagementContext : DbContext
    {
        public PortfolioManagementContext(DbContextOptions<PortfolioManagementContext> options) : base(options) { }

        public DbSet<FinancialProduct> FinancialProducts { get; set; }
        public DbSet<Investment> Investments { get; set; }
    }
}
