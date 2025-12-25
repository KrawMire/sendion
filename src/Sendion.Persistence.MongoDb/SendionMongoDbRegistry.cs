using Microsoft.Extensions.DependencyInjection;
using Sendion.Core;
using Sendion.Core.Abstractions;
using Sendion.Persistence.MongoDb.Internal;

namespace Sendion.Persistence.MongoDb;

public static class SendionMongoDbRegistry
{
    public static ISendionBuilder AddMongoDb(this ISendionBuilder builder)
    {
        builder.Services.AddTransient<ISendionPersistence, MongoDbSendionPersistence>();
        return builder;
    }
}
