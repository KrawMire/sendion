using Sendion.Core.Models;

namespace Sendion.Core.Abstractions;

public interface ISendionTransport
{
    public void Send(SendionMessage message);
    public Task SendAsync(SendionMessage message);
}
