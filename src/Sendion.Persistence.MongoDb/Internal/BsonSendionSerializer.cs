using System.Runtime.Serialization;
using System.Text.Json;
using MongoDB.Bson;
using Sendion.Core.Models;
using Sendion.Persistence.MongoDb.Abstractions;

namespace Sendion.Persistence.MongoDb.Internal;

internal sealed class BsonSendionSerializer : ISendionMongoSerializer
{
    /// <summary>
    /// Default implementation of the serializing method.
    /// It first serializes the message payload to JSON, then parses it into a BsonDocument.
    /// </summary>
    /// <param name="data">The core Sendion message.</param>
    /// <returns>MongoDB representation of the Sendion message.</returns>
    public MongoDbSendionMessage Serialize(SendionMessage data)
    {
        var json = JsonSerializer.Serialize(data.Payload);

        return new MongoDbSendionMessage
        {
            Id = data.Id is null ? ObjectId.Empty : ObjectId.Parse(data.Id),
            Destination = data.Destination,
            Status = SendionMessageStatus.Pending.ToStatusString(),
            Payload = BsonDocument.Parse(json),
            CreatedAt = data.CreatedAt,
        };
    }

    /// <summary>
    /// Default implementation of the deserializing method.
    /// It converts the BsonDocument payload to a dictionary and creates a SendionMessage instance.
    /// </summary>
    /// <param name="data">The MongoDB representation of the Sendion message to deserialize.</param>
    /// <returns>The deserialized Sendion message.</returns>
    public SendionMessage Deserialize(MongoDbSendionMessage data)
    {
        var payload = data.Payload?.ToDictionary();
        var message = new SendionMessage
        {
            Id = data.Id.ToString(),
            Destination = data.Destination,
            Status = data.Status.ToSendionMessageStatus(),
            Payload = payload,
            CreatedAt = data.CreatedAt,
        };

        return message;
    }
}
