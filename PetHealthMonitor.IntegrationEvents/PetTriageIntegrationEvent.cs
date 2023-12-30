namespace PetHealthMonitor.IntegrationEvents;

public class PetTriageIntegrationEvent
{
    public Guid PetId { get; set; }
    public double Temperature { get; set; }
    public string Observation { get; set; }

    public PetTriageIntegrationEvent(Guid petId, double temperature, string observation)
    {
        PetId = petId;
        Temperature = temperature;
        Observation = observation;
    }
}