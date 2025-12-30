using Microsoft.Extensions.DependencyInjection;
using Sendion.Core;

namespace Sendion.Hosting;

public static class SendionHostingRegistry
{
    public static ISendionBuilder AddBackgroundService(this ISendionBuilder builder)
    {
        builder.Services.AddHostedService<SendionBackgroundService>();
        return builder;
    }
}
