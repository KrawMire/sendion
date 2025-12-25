using Microsoft.Extensions.DependencyInjection;

namespace Sendion.Core;

public interface ISendionBuilder
{
    public IServiceCollection Services { get; }
}
