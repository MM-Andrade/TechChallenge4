namespace PetHealthMonitor.Domain.Triages
{
    public class TemperatureTriage : ITemperatureTriage
    {
        public Guid PetId { get; set; } = Guid.Empty;

        public double Temperature { get; set; }

        public string? Observations { get; set; }
    }
}
