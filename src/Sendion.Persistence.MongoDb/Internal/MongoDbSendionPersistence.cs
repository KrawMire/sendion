using System.Text;
using System.Text.Json;
using MongoDB.Driver;
using Sendion.Core.Abstractions;
using Sendion.Core.Models;
using Sendion.Persistence.MongoDb.Configuration;

namespace Sendion.Persistence.MongoDb.Internal;

internal sealed class MongoDbSendionPersistence : ISendionPersistence
{
    private readonly IMongoClient _mongoClient;
    private readonly SendionMongoDbOptions _options;
    private readonly IMongoCollection<MongoDbSendionMessage> _collection;

    public MongoDbSendionPersistence(IMongoClient mongoClient, SendionMongoDbOptions options)
    {
        _mongoClient = mongoClient;
        _options = options;

        var db = _mongoClient.GetDatabase(_options.DatabaseName);
        _collection = db.GetCollection<MongoDbSendionMessage>(_options.CollectionName);
    }

    public void Persist(SendionMessage message)
    {
        var payloadJson = JsonSerializer.Serialize(message.Payload);
        var payloadBytes = Encoding.UTF8.GetBytes(payloadJson);

        var msg = new MongoDbSendionMessage
        {
            Payload = payloadBytes,
            CreatedAt = message.CreatedAt,
        };

        _collection.InsertOne(msg);
    }

    public Task PersistAsync(SendionMessage message)
    {
        var payloadJson = JsonSerializer.Serialize(message.Payload);
        var payloadBytes = Encoding.UTF8.GetBytes(payloadJson);

        var msg = new MongoDbSendionMessage
        {
            Payload = payloadBytes,
            CreatedAt = message.CreatedAt,
        };

        return _collection.InsertOneAsync(msg);
    }
}
