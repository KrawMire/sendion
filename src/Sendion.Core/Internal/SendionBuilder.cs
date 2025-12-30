using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sendion.Core.Abstractions;

namespace Sendion.Core.Internal;

internal sealed class SendionBuilder : ISendionBuilder
{
    public SendionBuilder(IServiceCollection services)
    {
        Services = services;
    }

    public IServiceCollection Services { get; }

    public void Build()
    {
        Services.TryAddSingleton<ISendionMessageSerializer<byte[]>, JsonSendionSerializer>();
    }
}
