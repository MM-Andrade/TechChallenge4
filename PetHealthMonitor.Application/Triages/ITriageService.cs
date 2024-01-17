using PetHealthMonitor.Domain.Triages;

namespace PetHealthMonitor.Application.Triages
{
    public interface ITriageService
    {
        Task RecordTriage(TemperatureTriage triage);
    }
}
