using Microsoft.EntityFrameworkCore;
using PortfolioManagement.Models;

namespace PortfolioManagement.Data
{
    public class PortfolioManagementContext : DbContext
    {
        public PortfolioManagementContext(DbContextOptions<PortfolioManagementContext> options) : base(options) { }

        public DbSet<FinancialProduct> FinancialProducts { get; set; }
        public DbSet<Investment> Investments { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Investment>()
                .HasOne(i => i.Client)
                .WithMany(c => c.Investments)
                .HasForeignKey(i => i.ClientId);

            modelBuilder.Entity<Investment>()
                .HasOne(i => i.FinancialProduct)
                .WithMany()
                .HasForeignKey(i => i.FinancialProductId);
        }
    }
}
