namespace MooWordsWorkers.Workers;

public static class DependencyInjection
{
    public static IServiceCollection AddWorkerServices(this IServiceCollection services)
    {
        services.AddHostedService<Worker>();

        return services;
    }
}
