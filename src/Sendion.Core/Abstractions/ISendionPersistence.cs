using Sendion.Core.Models;

namespace Sendion.Core.Abstractions;

public interface ISendionPersistence
{
    void Persist(SendionMessage message);
    Task PersistAsync(SendionMessage message);
    Task<IEnumerable<SendionMessage>> GetPendingMessagesAsync();
    Task SetProcessingStatusAsync(string messageId);
    Task SetPublishedStatusAsync(string messageId);
    Task SetFailedStatusAsync(string messageId);
}
