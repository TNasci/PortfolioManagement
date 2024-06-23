using Microsoft.AspNetCore.Mvc;
using PortfolioManagement.Services;

namespace PortfolioManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly EmailService _emailService;

        public NotificationsController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send-daily-notifications")]
        public async Task<IActionResult> SendDailyNotifications()
        {
            await _emailService.SendDailyNotifications();
            return Ok("Notificações enviadas com sucesso!");
        }
    }
}
