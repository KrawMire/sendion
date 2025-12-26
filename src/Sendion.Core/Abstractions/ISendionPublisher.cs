using Sendion.Core.Models;

namespace Sendion.Core.Abstractions;

public interface ISendionPublisher
{
    void Publish(string destination, SendionMessage message);
    Task PublishAsync(string destination, SendionMessage message);
}
