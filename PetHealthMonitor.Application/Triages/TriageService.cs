using Microsoft.Extensions.Logging;
using PetHealthMonitor.Domain.Pets;
using PetHealthMonitor.Domain.Triages;

namespace PetHealthMonitor.Application.Triages
{
    public class TriageService : ITriageService
    {
        private readonly ILogger<TriageService> _logger;
        private readonly IPetRepository _petRepository;

        public TriageService(ILogger<TriageService> logger, IPetRepository petRepository)
        {
            _logger = logger;
            _petRepository = petRepository;
        }

        public async void RecordTriage(Guid petId, double temperature, string? observations = null)
        {
            _logger.LogInformation($"Getting pet by id {petId}");
            var pet = _petRepository.GetById(petId);

            if (pet == null)
            {
                _logger.LogError($"Pet by id {petId} not found.");
                throw new Exception("Pet not found.");
            }

            //TODO: Implementar bus para publicar o evento de triagem
            //await _bus.Publish<ITriageReading>(new
            //{
            //    PetId = petId,
            //    Temperature = temperature,
            //    Observations = observations
            //});

            _logger.LogInformation($"Recording triage for Pet {petId}: Temperature {temperature}°C");
        }
    }
}
