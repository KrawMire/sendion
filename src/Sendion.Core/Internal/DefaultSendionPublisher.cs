using Sendion.Core.Abstractions;
using Sendion.Core.Models;

namespace Sendion.Core.Internal;

internal sealed class DefaultSendionPublisher(ISendionPersistence persistence) : ISendionPublisher
{
    public void Publish(string destination, SendionMessage message)
    {
        message.Destination = destination;
        message.CreatedAt = DateTime.UtcNow;

        persistence.Persist(message);
    }

    public async Task PublishAsync(string destination, SendionMessage message)
    {
        message.Destination = destination;
        message.CreatedAt = DateTime.UtcNow;

        await persistence.PersistAsync(message).ConfigureAwait(false);
    }
}
