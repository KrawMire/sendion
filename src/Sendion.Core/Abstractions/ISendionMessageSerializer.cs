using Sendion.Core.Models;

namespace Sendion.Core.Abstractions;

public interface ISendionMessageSerializer<TRepresent>
{
    TRepresent Serialize(SendionMessage msg);
    SendionMessage? Deserialize(TRepresent data);
}
