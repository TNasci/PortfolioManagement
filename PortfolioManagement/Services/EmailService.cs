using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using PortfolioManagement.Data;

namespace PortfolioManagement.Services
{
    public class EmailService
    {
        private readonly PortfolioManagementContext _context;
        private readonly IConfiguration _configuration;

        public EmailService(PortfolioManagementContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task SendDailyNotifications()
        {
            var products = await _context.FinancialProducts
                .Where(p => p.MaturityDate <= DateTime.Today.AddDays(7))
                .ToListAsync();

            if (products.Any())
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Portfolio Management", _configuration["Smtp:Username"]));
                message.To.Add(new MailboxAddress("Admin", "email_adm"));
                message.Subject = "Produtos Financeiros com Vencimento Próximo";

                var bodyBuilder = new BodyBuilder
                {
                    TextBody = "Os seguintes produtos financeiros estão com vencimento próximo:\n" +
                               string.Join("\n", products.Select(p => $"{p.Name} - {p.MaturityDate:dd/MM/yyyy}"))
                };

                message.Body = bodyBuilder.ToMessageBody();

                using var client = new SmtpClient();
                await client.ConnectAsync(_configuration["Smtp:Server"], int.Parse(_configuration["Smtp:Port"]), SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_configuration["Smtp:Username"], _configuration["Smtp:Password"]);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
