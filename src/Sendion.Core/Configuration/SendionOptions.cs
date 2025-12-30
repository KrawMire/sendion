namespace Sendion.Core.Configuration;

public class SendionOptions
{
    public int PollingFrequencyMilliseconds { get; set; } = (int)TimeSpan.FromSeconds(5).TotalMilliseconds;
}
