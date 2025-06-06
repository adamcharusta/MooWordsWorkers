using Microsoft.Extensions.DependencyInjection;

namespace MooWordsWorkers.NotificationService;

public static class DependencyInjection
{
    public static IServiceCollection AddNotificationServices(this IServiceCollection services)
    {
        return services;
    }
}
