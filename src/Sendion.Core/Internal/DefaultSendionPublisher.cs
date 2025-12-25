using Sendion.Core.Abstractions;
using Sendion.Core.Models;

namespace Sendion.Core.Internal;

internal sealed class DefaultSendionPublisher : ISendionPublisher
{
    private readonly ISendionPersistence _persistence;

    public DefaultSendionPublisher(ISendionPersistence persistence)
    {
        _persistence = persistence;
    }

    public void Publish(SendionMessage message)
    {
        _persistence.Persist(message);
    }

    public Task PublishAsync(SendionMessage message)
    {
        return _persistence.PersistAsync(message);
    }
}
