using MassTransit;
using PetHealthMonitor.IntegrationEvents;

namespace PetHealthMonitor.Consumer.IntegrationEventsHandlers;

public class PetTriageIntegrationEventHandler : IConsumer<PetTriageIntegrationEvent>
{
    public Task Consume(ConsumeContext<PetTriageIntegrationEvent> context)
    {
        var petId = context.Message.PetId;
        var temperature = context.Message.Temperature;
        var hasFever = temperature >= 40;

        if (hasFever)
        {
            Console.WriteLine($"Pet#{petId} has fever!");
        } else
        {
            Console.WriteLine($"Pet#{petId} has no fever!");
        }

        return Task.CompletedTask;
    }
}
