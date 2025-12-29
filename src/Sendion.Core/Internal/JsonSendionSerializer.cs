using System.Text.Json;
using Sendion.Core.Abstractions;
using Sendion.Core.Models;

namespace Sendion.Core.Internal;

internal sealed class JsonSendionSerializer : ISendionMessageSerializer<byte[]>
{
    private readonly JsonSerializerOptions _options = new();

    public byte[] Serialize(SendionMessage data)
        => JsonSerializer.SerializeToUtf8Bytes(data, _options);

    public SendionMessage? Deserialize(byte[] data)
        => JsonSerializer.Deserialize<SendionMessage>(data, _options);
}
