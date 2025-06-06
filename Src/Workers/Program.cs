using MooWordsWorkers.EmailService;
using MooWordsWorkers.Infrastructure;
using MooWordsWorkers.NotificationService;
using MooWordsWorkers.Workers;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    var builder = Host.CreateApplicationBuilder(args);
    builder.Services
        .AddInfrastructureServices(builder.Configuration)
        .AddNotificationServices()
        .AddEmailServices()
        .AddWorkerServices();

    var host = builder.Build();
    host.Run();
}
catch (Exception e)
{
    Log.Fatal(e, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}
