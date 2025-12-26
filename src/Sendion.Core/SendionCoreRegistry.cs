using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sendion.Core.Abstractions;
using Sendion.Core.Configuration;
using Sendion.Core.Internal;

namespace Sendion.Core;

public static class SendionCoreRegistry
{
    public static ISendionBuilder AddSendion(this IServiceCollection services)
    {
        var options = new SendionOptions();
        return services.AddSendion(options);
    }

    public static ISendionBuilder AddSendion(this IServiceCollection services, SendionOptions options)
    {
        var builder = new SendionBuilder(services);

        builder.Services.TryAddSingleton<ISendionPublisher, DefaultSendionPublisher>();
        builder.Services.TryAddSingleton(options);

        return builder;
    }
}
