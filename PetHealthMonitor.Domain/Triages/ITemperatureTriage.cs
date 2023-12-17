namespace PetHealthMonitor.Domain.Triages
{
    public interface ITemperatureTriage
    {
        Guid PetId { get; }
        double Temperature { get; }
        string? Observations { get; }
    }
}
