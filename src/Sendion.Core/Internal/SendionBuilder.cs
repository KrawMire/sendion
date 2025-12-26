using Microsoft.Extensions.DependencyInjection;

namespace Sendion.Core.Internal;

internal sealed class SendionBuilder : ISendionBuilder
{
    public SendionBuilder(IServiceCollection services)
    {
        Services = services;
    }

    public IServiceCollection Services { get; }
}
