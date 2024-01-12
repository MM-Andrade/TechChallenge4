using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using PetHealthMonitor.Domain.Triages;
using System.Text.Json;

namespace PetHealthMonitor.Function.Consumer
{
    public class FConsumerRabbitMQTrigger
    {
        private readonly ILogger _logger;

        public FConsumerRabbitMQTrigger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FConsumerRabbitMQTrigger>();
        }

        [Function("ConsumerRabbitMQTrigger")]
        public void Run([RabbitMQTrigger("PetHealthMonitor.Queue", ConnectionStringSetting = "MassTransitSettings")] string myQueueItem)
        {
            var message = $"Message received: {myQueueItem}";
            _logger.LogInformation(message);

            var ferver = JsonSerializer.Deserialize<TemperatureTriage>(myQueueItem);
            _logger.LogInformation($"Pet received: {ferver.PetId} \nFerver: {ferver.Temperature}");
            
        }
    }
}
