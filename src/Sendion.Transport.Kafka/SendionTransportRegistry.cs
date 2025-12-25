using Microsoft.Extensions.DependencyInjection;
using Sendion.Core;
using Sendion.Core.Abstractions;
using Sendion.Transport.Kafka.Internal;

namespace Sendion.Transport.Kafka;

public static class SendionTransportRegistry
{
    public static ISendionBuilder AddKafka(this ISendionBuilder builder)
    {
        builder.Services.AddTransient<ISendionTransport, KafkaSendionTransport>();
        return builder;
    }
}
