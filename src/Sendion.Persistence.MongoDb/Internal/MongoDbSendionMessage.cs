using MongoDB.Bson;

namespace Sendion.Persistence.MongoDb.Internal;

/// <summary>
/// MongoDB representation of a Sendion message.
/// </summary>
public class MongoDbSendionMessage
{
    /// <summary>
    /// Unique identifier of the message.
    /// </summary>
    public ObjectId Id { get; set; }

    /// <summary>
    /// The destination of the message. It could be a queue, topic,
    /// or any other destination in a messagin system.
    /// </summary>
    public required string Destination { get; set; }

    /// <summary>
    /// The current status string representation of the message.
    /// </summary>
    public required string Status { get; set; }

    /// <summary>
    /// The dynamic payload of the message.
    /// </summary>
    public BsonDocument? Payload { get; set; }

    /// <summary>
    /// Timestamp indicating when the message was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}
