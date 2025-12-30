using System.Text.Json;
using Confluent.Kafka;
using Sendion.Core.Abstractions;
using Sendion.Core.Models;

namespace Sendion.Transport.Kafka.Internal;

internal sealed class KafkaSendionTransport : ISendionTransport
{
    private readonly IProducer<Null, string> _producer;

    public KafkaSendionTransport(IProducer<Null, string> producer)
    {
        _producer = producer;
    }

    public void Send(SendionMessage message)
    {
        var content = JsonSerializer.Serialize(message.Payload);
        var msg = new Message<Null, string>
        {
            Value = content,
        };

        _producer.Produce(message.Destination, msg);
    }

    public Task SendAsync(SendionMessage message)
    {
        var content = JsonSerializer.Serialize(message.Payload);
        var msg = new Message<Null, string>
        {
            Value = content,
        };

        return _producer.ProduceAsync(message.Destination, msg);
    }
}
