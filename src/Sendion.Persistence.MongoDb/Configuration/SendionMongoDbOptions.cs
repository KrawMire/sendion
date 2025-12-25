namespace Sendion.Persistence.MongoDb.Configuration;

public class SendionMongoDbOptions
{
    public required string ConnectionString { get; set; }
    public string DatabaseName { get; set; } = "sendion";
    public string CollectionName { get; set; } = "outbox";
    public bool NeedOpenTransaction { get; set; } = false;
}
