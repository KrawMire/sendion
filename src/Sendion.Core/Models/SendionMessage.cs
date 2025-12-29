namespace Sendion.Core.Models;

/// <summary>
/// Represents a message used in the Sendion.
/// This class encapsulates all necessary information
/// for handling and tracking the lifecycle of a message.
/// </summary>
public class SendionMessage
{
    /// <summary>
    /// The unique identifier for the message.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// The identifier used to correlate messages across different systems or processes.
    /// This value helps in associating related messages
    /// or tracing the flow of a specific message instance.
    /// </summary>
    public string? CorrelationId { get; set; }

    /// <summary>
    /// The content of the message being transmitted.
    /// This property holds the actual data or object
    /// that the message represents and can be of any type.
    /// </summary>
    public object? Payload { get; set; }

    /// <summary>
    /// Specifies the target location where the message will be sent.
    /// This property is set internally by the publisher to indicate the intended destination
    /// for the message in the messaging system.
    /// </summary>
    public string Destination { get; internal set; } = null!;

    /// <summary>
    /// Specifies the partition key associated with the message.
    /// This key is used to determine the logical partition
    /// within a data storage or messaging system for the message.
    /// </summary>
    public string? PartitionKey { get; set; }

    /// <summary>
    /// Indicates the current status of the message in its lifecycle.
    /// Possible values include Pending, Processing, Published, and Failed,
    /// representing the different states a message can be in during
    /// its handling and delivery process.
    /// </summary>
    public SendionMessageStatus Status { get; set; } = SendionMessageStatus.Pending;

    /// <summary>
    /// The timestamp indicating when the message was created.
    /// This is initialized with the current UTC time upon message creation.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// The timestamp indicating when the message was taken for processing.
    /// This property is nullable and will have a value only after the processing of
    /// the message has started.
    /// </summary>
    public DateTime? TakenToProcessAt { get; set; }

    /// <summary>
    /// The date and time when the message was successfully published.
    /// </summary>
    public DateTime? PublishedAt { get; set; }

    /// <summary>
    /// The number of times the message has been retried for processing or delivery.
    /// </summary>
    public int RetryCount { get; set; } = 0;

    /// <summary>
    /// Information about the last error encountered during message processing.
    /// This property is used to store error details when the message processing fails,
    /// enabling further inspection or debugging.
    /// </summary>
    public string? LastError { get; set; }
}
