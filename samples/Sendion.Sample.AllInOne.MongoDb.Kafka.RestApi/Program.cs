using Sendion.Core;
using Sendion.Hosting;
using Sendion.Persistence.MongoDb;
using Sendion.Persistence.MongoDb.Configuration;
using Sendion.Transport.Kafka;
using Sendion.Transport.Kafka.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var persistenceOptions = builder.Configuration
    .GetSection("Outbox:Persistence")
    .Get<SendionMongoDbOptions>();

var transportOptions = builder.Configuration
    .GetSection("Outbox:Transport")
    .Get<SendionKafkaOptions>();

builder.Services
    .AddSendion()
    .AddBackgroundService()
    .AddMongoDb(persistenceOptions)
    .AddKafka(transportOptions)
    .Build();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
