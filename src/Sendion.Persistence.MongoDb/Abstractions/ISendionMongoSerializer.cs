using Sendion.Core.Abstractions;
using Sendion.Persistence.MongoDb.Internal;

namespace Sendion.Persistence.MongoDb.Abstractions;

/// <summary>
/// Defines methods for serializing and deserializing messages between
/// the core Sendion message format and the MongoDB-specific representation.
/// </summary>
public interface ISendionMongoSerializer : ISendionMessageSerializer<MongoDbSendionMessage>;
