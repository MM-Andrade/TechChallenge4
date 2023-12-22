namespace PetHealthMonitor.IntegrationEvents;

public class PetTriageIntegrationEvent
{
    public Guid PetId { get; set; }
    public double Temperature { get; set; }

    public PetTriageIntegrationEvent(Guid petId, double temperature)
    {
        PetId = petId;
        Temperature = temperature;
    }
}