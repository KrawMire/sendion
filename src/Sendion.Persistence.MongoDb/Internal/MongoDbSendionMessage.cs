namespace Sendion.Persistence.MongoDb.Internal;

public class MongoDbSendionMessage
{
    public byte[]? Payload { get; set; }
    public DateTime CreatedAt { get; set; }
}
