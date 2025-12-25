using Sendion.Core.Models;

namespace Sendion.Core.Abstractions;

public interface ISendionPublisher
{
    void Publish(SendionMessage message);
    Task PublishAsync(SendionMessage message);
}
