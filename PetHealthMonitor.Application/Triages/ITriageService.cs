using PetHealthMonitor.Domain.Triages;

namespace PetHealthMonitor.Application.Triages
{
    public interface ITriageService
    {
        void RecordTriage(TemperatureTriage triage);
    }
}
