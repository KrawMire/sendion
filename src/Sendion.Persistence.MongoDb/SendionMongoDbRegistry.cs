using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using Sendion.Core;
using Sendion.Core.Abstractions;
using Sendion.Persistence.MongoDb.Configuration;
using Sendion.Persistence.MongoDb.Internal;

namespace Sendion.Persistence.MongoDb;

public static class SendionMongoDbRegistry
{
    public static ISendionBuilder AddMongoDb(this ISendionBuilder builder)
    {
        var options = new SendionMongoDbOptions();
        return builder.AddMongoDb(options);
    }

    public static ISendionBuilder AddMongoDb(this ISendionBuilder builder, SendionMongoDbOptions options)
    {
        var client = new MongoClient(options.ConnectionString);

        RegisterMongoMappings();

        builder.Services.TryAddSingleton<IMongoClient>(client);
        builder.Services.TryAddTransient<ISendionPersistence, MongoDbSendionPersistence>();
        builder.Services.TryAddSingleton(options);

        return builder;
    }

    private static void RegisterMongoMappings()
    {

    }
}
