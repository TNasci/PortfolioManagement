using PortfolioManagement.Services;

public class TimedHostedService : IHostedService, IDisposable
{
    private Timer _timer;
    private readonly IServiceProvider _services;

    public TimedHostedService(IServiceProvider services)
    {
        _services = services;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromDays(1));
        return Task.CompletedTask;
    }

    private void DoWork(object state)
    {
        using (var scope = _services.CreateScope())
        {
            var emailService = scope.ServiceProvider.GetRequiredService<EmailService>();
            emailService.SendDailyNotifications().GetAwaiter().GetResult();
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
