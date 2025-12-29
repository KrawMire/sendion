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
