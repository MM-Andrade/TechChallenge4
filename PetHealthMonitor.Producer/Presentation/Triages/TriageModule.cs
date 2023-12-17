using PetHealthMonitor.Application.Triages;
using PetHealthMonitor.Domain.Triages;

namespace PetHealthMonitor.Producer.Presentation.Triages
{
    public static class TriageModule
    {
        public static void AddTriageEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/triages/record", (ITriageService triageService, TemperatureTriage triage) =>
            {
                triageService.RecordTriage(triage.PetId, triage.Temperature, triage.Observations);

                return Results.Ok();
            }).AllowAnonymous();
        }
    }
}