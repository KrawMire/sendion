using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sendion.Core.Abstractions;
using Sendion.Core.Configuration;

namespace Sendion.Hosting;

internal sealed class SendionBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<SendionBackgroundService> _logger;
    private readonly SendionOptions _options;

    public SendionBackgroundService(
        IServiceProvider serviceProvider,
        ILogger<SendionBackgroundService> logger,
        SendionOptions options)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
        _options = options;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Sendion background service started.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await ProcessOutboxAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred.");
            }

            await Task.Delay(_options.PollingFrequencyMilliseconds, stoppingToken);
        }
    }

    private async Task ProcessOutboxAsync(CancellationToken stoppingToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var persistence = scope.ServiceProvider.GetRequiredService<ISendionPersistence>();
        var transport = scope.ServiceProvider.GetRequiredService<ISendionTransport>();

        var messages = await persistence.GetPendingMessagesAsync();

        foreach (var message in messages)
        {
            if (message.Id is null)
            {
                _logger.LogError("Message ID is null, skipping processing.");
                continue;
            }

            await persistence.SetProcessingStatusAsync(message.Id);
            await transport.SendAsync(message);
            await persistence.SetPublishedStatusAsync(message.Id);
        }
    }
}
