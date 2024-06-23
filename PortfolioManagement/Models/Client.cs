using System.ComponentModel.DataAnnotations;

namespace PortfolioManagement.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string CPF { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(15)]
        public string Telefone { get; set; }

        public virtual ICollection<Investment> Investments { get; set; }
    }
}
