namespace Sendion.Persistence.MongoDb.Configuration;

public class SendionMongoDbOptions
{
    public string ConnectionString { get; set; } = "mongodb://localhost:27017";
    public string DatabaseName { get; set; } = "sendion";
    public string CollectionName { get; set; } = "outbox";
    public bool NeedOpenTransaction { get; set; }
}
