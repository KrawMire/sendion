using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Sendion.Core;
using Sendion.Core.Abstractions;
using Sendion.Persistence.MongoDb.Abstractions;
using Sendion.Persistence.MongoDb.Configuration;
using Sendion.Persistence.MongoDb.Internal;

namespace Sendion.Persistence.MongoDb;

/// <summary>
/// Provides dependency injection registration methods
/// for the Sendion MongoDb persistence layer.
/// </summary>
public static class SendionMongoDbRegistry
{
    /// <summary>
    /// Register the Sendion MongoDB persistence layer
    /// with the default parameters.
    /// </summary>
    /// <param name="builder">A builder object of the Sendion.</param>
    /// <returns>The builder with registered dependencies.</returns>
    public static ISendionBuilder AddMongoDb(this ISendionBuilder builder)
    {
        var options = new SendionMongoDbOptions();
        return builder.AddMongoDb(options);
    }

    /// <summary>
    /// Register the Sendion MongoDB persistence layer with custom parameters.
    /// </summary>
    /// <param name="builder">A builder object of the Sendion.</param>
    /// <param name="options">A set of parameters for configuring of the Sendion MongoDB persistence layer.</param>
    /// <returns>The builder with registered dependencies.</returns>
    public static ISendionBuilder AddMongoDb(this ISendionBuilder builder, SendionMongoDbOptions options)
    {
        var client = new MongoClient(options.ConnectionString);

        builder.Services.TryAddSingleton<IMongoClient>(client);
        builder.Services.TryAddTransient<ISendionPersistence, MongoDbSendionPersistence>();
        builder.Services.TryAddSingleton(options);

        builder.Services.TryAddSingleton<ISendionMongoSerializer, BsonSendionSerializer>();

        return builder;
    }
}
