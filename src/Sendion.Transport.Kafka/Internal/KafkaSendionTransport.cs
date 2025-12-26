using Confluent.Kafka;
using Sendion.Core.Abstractions;

namespace Sendion.Transport.Kafka.Internal;

internal sealed class KafkaSendionTransport : ISendionTransport
{
    private readonly IProducer<Null, string> _producer;

    public KafkaSendionTransport(IProducer<Null, string> producer)
    {
        _producer = producer;
    }

    public void Send(string message)
    {
        var msg = new Message<Null, string> { Value = message };
        _producer.Produce("", msg);
    }

    public Task SendAsync(string message)
    {
        throw new NotImplementedException();
    }
}
