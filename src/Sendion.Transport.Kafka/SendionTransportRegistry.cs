using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sendion.Core;
using Sendion.Core.Abstractions;
using Sendion.Transport.Kafka.Configuration;
using Sendion.Transport.Kafka.Internal;

namespace Sendion.Transport.Kafka;

public static class SendionTransportRegistry
{
    public static ISendionBuilder AddKafka(this ISendionBuilder builder, SendionKafkaOptions options)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = options.BootstrapServers,
        };

        var producer = new ProducerBuilder<Null, string>(config).Build();

        builder.Services.TryAddSingleton(producer);
        builder.Services.TryAddTransient<ISendionTransport, KafkaSendionTransport>();
        return builder;
    }
}
