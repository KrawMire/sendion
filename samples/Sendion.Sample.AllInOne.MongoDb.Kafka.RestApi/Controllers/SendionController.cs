using Microsoft.AspNetCore.Mvc;
using Sendion.Core.Abstractions;
using Sendion.Core.Models;

namespace Sendion.Sample.AllInOne.MongoDb.Kafka.RestApi.Controllers;

[ApiController]
[Route("sendion")]
public class SendionController(ISendionPublisher publisher) : ControllerBase
{
    private const string Topic = "sendion.sample";

    [HttpPost("async")]
    public async Task<IActionResult> SendAsync([FromBody] object message)
    {
        var msg = new SendionMessage
        {
            Payload = message,
        };

        await publisher.PublishAsync(Topic, msg);

        return Ok();
    }

    [HttpPost("sync")]
    public IActionResult Send([FromBody] object message)
    {
        var msg = new SendionMessage
        {
            Payload = message,
        };

        publisher.Publish(Topic, msg);

        return Ok();
    }
}
