using Sendion.Core;
using Sendion.Persistence.MongoDb;
using Sendion.Persistence.MongoDb.Configuration;

var builder = WebApplication.CreateBuilder(args);

var persistenceOptions = builder.Configuration
    .GetSection("Outbox:Persistence")
    .Get<SendionMongoDbOptions>();

builder.Services.AddSendion().AddMongoDb(persistenceOptions);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();