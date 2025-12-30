namespace Sendion.Transport.Kafka.Configuration;

public class SendionKafkaOptions
{
    public required string BootstrapServers { get; set; } = "localhost:9092"
}
