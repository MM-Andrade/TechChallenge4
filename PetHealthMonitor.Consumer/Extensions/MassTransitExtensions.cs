using MassTransit;
using PetHealthMonitor.Consumer.IntegrationEventsHandlers;
using PetHealthMonitor.Infrastructure.Settings;

namespace PetHealthMonitor.Consumer.Extensions;

public static class MassTransitExtensions
{
    public static void AddMassTransit(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.GetSection("MassTransitSettings").Get<MassTransitSettings>();

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(settings?.Host, "/", host =>
                {
                    host.Username(settings?.Username);
                    host.Password(settings?.Password);
                });
                cfg.ReceiveEndpoint(settings?.EndpointName, e =>
                {
                    e.Consumer<PetTriageIntegrationEventHandler>();
                });
                cfg.ConfigureEndpoints(context);
            });

            x.AddConsumer<PetTriageIntegrationEventHandler>();
        });
    }
}
