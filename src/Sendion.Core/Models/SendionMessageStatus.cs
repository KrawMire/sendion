namespace Sendion.Core.Models;

/// <summary>
/// The set of possible statuses for a Sendion message.
/// </summary>
public enum SendionMessageStatus
{
    /// <summary>
    /// The message is waiting to be processed.
    /// This is the initial status for a new message.
    /// </summary>
    Pending,

    /// <summary>
    /// The message has been taken from the persistence provider
    /// but not yet published to the transport provider.
    /// </summary>
    Processing,

    /// <summary>
    /// The message has been successfully
    /// published to the transport provider.
    /// </summary>
    Published,

    /// <summary>
    /// The message processing failed.
    /// </summary>
    Failed,
}

public static class SendionMessageStatusExtensions
{
    private static readonly Dictionary<string, SendionMessageStatus> StatusMap = new()
    {
        { Enum.GetName(typeof(SendionMessageStatus), SendionMessageStatus.Pending)!, SendionMessageStatus.Pending },
        { Enum.GetName(typeof(SendionMessageStatus), SendionMessageStatus.Processing)!, SendionMessageStatus.Processing },
        { Enum.GetName(typeof(SendionMessageStatus), SendionMessageStatus.Published)!, SendionMessageStatus.Published },
        { Enum.GetName(typeof(SendionMessageStatus), SendionMessageStatus.Failed)!, SendionMessageStatus.Failed },
    };

    public static string ToStatusString(this SendionMessageStatus status)
        => Enum.GetName(status.GetType(), status)!;

    public static SendionMessageStatus ToSendionMessageStatus(this string status)
    {
        var result = StatusMap.TryGetValue(status, out var messageStatus);

        return result
            ? messageStatus
            : throw new ArgumentException($"Invalid status: {status}");
    }
}
