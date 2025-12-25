using MongoDB.Driver;
using Sendion.Core.Abstractions;
using Sendion.Core.Models;
using Sendion.Persistence.MongoDb.Configuration;

namespace Sendion.Persistence.MongoDb.Internal;

internal sealed class MongoDbSendionPersistence : ISendionPersistence
{
    private readonly IMongoClient _mongoClient;
    private readonly SendionMongoDbOptions _options;
    private readonly IMongoCollection<SendionMessage> _collection;

    public MongoDbSendionPersistence(IMongoClient mongoClient, SendionMongoDbOptions options)
    {
        _mongoClient = mongoClient;
        _options = options;

        var db = _mongoClient.GetDatabase(_options.DatabaseName);
        _collection = db.GetCollection<SendionMessage>(_options.CollectionName);
    }

    public void Persist(SendionMessage message)
    {

    }

    public Task PersistAsync(SendionMessage message)
    {
        throw new NotImplementedException();
    }
}
