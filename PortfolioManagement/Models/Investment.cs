namespace PortfolioManagement.Models
{
    public class Investment
    {
        public int Id { get; set; }
        public int FinancialProductId { get; set; }
        public FinancialProduct? FinancialProduct { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }
        public decimal Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalValue { get; set; }
    }
}
