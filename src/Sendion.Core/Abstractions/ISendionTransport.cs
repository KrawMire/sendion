namespace Sendion.Core.Abstractions;

public interface ISendionTransport
{
    public void Send(string message);
    public Task SendAsync(string message);
}
