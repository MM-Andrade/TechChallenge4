namespace PetHealthMonitor.Application.Triages
{
    public interface ITriageService
    {
        void RecordTriage(Guid petId, double temperature, string? observations);
    }
}
