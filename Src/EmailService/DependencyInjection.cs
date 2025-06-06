using Microsoft.Extensions.DependencyInjection;

namespace MooWordsWorkers.EmailService;

public static class DependencyInjection
{
    public static IServiceCollection AddEmailServices(this IServiceCollection services)
    {
        return services;
    }
}
