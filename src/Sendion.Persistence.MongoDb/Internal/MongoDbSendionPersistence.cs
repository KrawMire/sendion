using MongoDB.Bson;
using MongoDB.Driver;
using Sendion.Core.Abstractions;
using Sendion.Core.Models;
using Sendion.Persistence.MongoDb.Abstractions;
using Sendion.Persistence.MongoDb.Configuration;

namespace Sendion.Persistence.MongoDb.Internal;

internal sealed class MongoDbSendionPersistence : ISendionPersistence
{
    private readonly IMongoClient _mongoClient;
    private readonly SendionMongoDbOptions _options;
    private readonly IMongoCollection<MongoDbSendionMessage> _collection;
    private readonly ISendionMongoSerializer _serializer;

    public MongoDbSendionPersistence(
        IMongoClient mongoClient,
        SendionMongoDbOptions options,
        ISendionMongoSerializer serializer)
    {
        _mongoClient = mongoClient;
        _options = options;
        _serializer = serializer;

        var db = _mongoClient.GetDatabase(_options.DatabaseName);
        _collection = db.GetCollection<MongoDbSendionMessage>(_options.CollectionName);
    }

    public void Persist(SendionMessage message)
    {
        var msg = _serializer.Serialize(message);
        _collection.InsertOne(msg);
    }

    public Task PersistAsync(SendionMessage message)
    {
        var msg = _serializer.Serialize(message);
        return _collection.InsertOneAsync(msg);
    }

    public async Task<IEnumerable<SendionMessage>> GetPendingMessagesAsync()
    {
        var status = SendionMessageStatus.Pending.ToStatusString();
        var messages = await _collection.Find(x => x.Status == status).ToListAsync();

        return messages.Select(_serializer.Deserialize);
    }

    public async Task SetProcessingStatusAsync(string messageId)
    {
        var targetStatus = SendionMessageStatus.Processing.ToStatusString();
        var updateDef = Builders<MongoDbSendionMessage>
            .Update
            .Set(m => m.Status, targetStatus);

        await _collection
            .UpdateOneAsync(m => m.Id == ObjectId.Parse(messageId), updateDef);
    }

    public async Task SetPublishedStatusAsync(string messageId)
    {
        var targetStatus = SendionMessageStatus.Published.ToStatusString();
        var updateDef = Builders<MongoDbSendionMessage>
            .Update
            .Set(m => m.Status, targetStatus);

        await _collection
            .UpdateOneAsync(m => m.Id == ObjectId.Parse(messageId), updateDef);
    }

    public async Task SetFailedStatusAsync(string messageId)
    {
        var targetStatus = SendionMessageStatus.Failed.ToStatusString();
        var updateDef = Builders<MongoDbSendionMessage>
            .Update
            .Set(m => m.Status, targetStatus);

        await _collection
            .UpdateOneAsync(m => m.Id == ObjectId.Parse(messageId), updateDef);
    }
}
