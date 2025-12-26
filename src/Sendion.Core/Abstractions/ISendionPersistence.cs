using Sendion.Core.Models;

namespace Sendion.Core.Abstractions;

public interface ISendionPersistence
{
    void Persist(SendionMessage message);
    Task PersistAsync(SendionMessage message);
}
