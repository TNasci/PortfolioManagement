namespace PortfolioManagement.Models
{
    public class FinancialProduct
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public decimal Price { get; set; }
        public DateTime MaturityDate { get; set; }
    }
}
