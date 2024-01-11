using MassTransit;
using PetHealthMonitor.Application.Triages;
using PetHealthMonitor.Domain.Triages;
using PetHealthMonitor.Infrastructure.Settings;
using PetHealthMonitor.IntegrationEvents;

namespace PetHealthMonitor.Producer.Presentation.Triages
{
    public static class TriageModule
    {
        public static void AddTriageEndpoints(this IEndpointRouteBuilder app, IConfiguration configuration)
        {
            app.MapPost("/triages/record", async (ITriageService triageService, IBus bus, TemperatureTriage triage) =>
            {
                await triageService.RecordTriage(triage);

                var massTransitSettings = configuration.GetSection("MassTransitSettings").Get<MassTransitSettings>();
                var endpoint = await bus.GetSendEndpoint(new Uri($"queue:{massTransitSettings?.EndpointName}"));
                await endpoint.Send(new PetTriageIntegrationEvent(triage.PetId, triage.Temperature));

                return Results.Ok();
            }).AllowAnonymous();
        }
    }
}