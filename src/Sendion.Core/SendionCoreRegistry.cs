using Microsoft.Extensions.DependencyInjection;
using Sendion.Core.Abstractions;
using Sendion.Core.Internal;

namespace Sendion.Core;

public static class SendionCoreRegistry
{
    public static ISendionBuilder AddSendion(this IServiceCollection services)
    {
        var builder = new SendionBuilder(services);
        builder.Services.AddSingleton<ISendionPublisher, DefaultSendionPublisher>();

        return builder;
    }
}
