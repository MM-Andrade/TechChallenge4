using MassTransit;
using Microsoft.Extensions.Logging;
using PetHealthMonitor.Domain.Pets;
using PetHealthMonitor.Domain.Triages;

namespace PetHealthMonitor.Application.Triages
{
    public class TriageService : ITriageService
    {
        private readonly ILogger<TriageService> _logger;
        private readonly IPetRepository _petRepository;
        private readonly IPublishEndpoint _bus;

        public TriageService(ILogger<TriageService> logger, IPetRepository petRepository, IPublishEndpoint bus)
        {
            _logger = logger;
            _petRepository = petRepository;
            _bus = bus;
        }

        public async void RecordTriage(TemperatureTriage triage)
        {
            _logger.LogInformation($"Getting pet by id {triage.PetId}");
            var pet = _petRepository.GetById(triage.PetId);

            if (pet == null)
            {
                _logger.LogError($"Pet by id {triage.PetId} not found.");
                throw new Exception("Pet not found.");
            }

            //TODO: Implementar bus para publicar o evento de triagem
            await _bus.Publish<ITemperatureTriage>(triage);

            _logger.LogInformation($"Recording triage for Pet {triage.PetId}: Temperature {triage.Temperature}°C");
        }
    }
}
