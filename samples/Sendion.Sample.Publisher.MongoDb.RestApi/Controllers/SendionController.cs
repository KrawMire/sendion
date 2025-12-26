using Microsoft.AspNetCore.Mvc;
using Sendion.Core.Abstractions;
using Sendion.Core.Models;
using Sendion.Sample.Publisher.MongoDb.Models;

namespace Sendion.Sample.Publisher.MongoDb.Controllers;

[ApiController]
[Route("sendion")]
public class SendionController(ISendionPublisher publisher) : ControllerBase
{
    private const string Topic = "sendion.sample";

    [HttpPost("async")]
    public async Task<IActionResult> SendAsync([FromBody] SampleMessage message)
    {
        var msg = new SendionMessage
        {
            Payload = message,
        };

        await publisher.PublishAsync(Topic, msg);

        return Ok();
    }

    [HttpPost("sync")]
    public IActionResult Send([FromBody] SampleMessage message)
    {
        var msg = new SendionMessage
        {
            Payload = message,
        };

        publisher.Publish(Topic, msg);

        return Ok();
    }
}
