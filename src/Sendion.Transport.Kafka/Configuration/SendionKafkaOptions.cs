namespace Sendion.Transport.Kafka.Configuration;

public class SendionKafkaOptions
{
    public required string BootstrapServers { get; set; }
    public string Topic { get; set; } = "sendion-messages";
}
