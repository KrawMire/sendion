namespace Sendion.Core.Models;

public class SendionMessage
{
    public string? Id { get; set; }
    public string? CorrelationId { get; set; }
    public object? Payload { get; set; }
    public string Destination { get; internal set; } = null!;
    public string? PartitionKey { get; set; }
    public SendionMessageStatus Status { get; set; } = SendionMessageStatus.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? TakenToProcessAt { get; set; }
    public DateTime? PublishedAt { get; set; }
    public int RetryCount { get; set; } = 0;
    public string? LastError { get; set; }
}
