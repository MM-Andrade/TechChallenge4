using MassTransit;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using PetHealthMonitor.Application.Triages;
using PetHealthMonitor.Domain.Pets;
using PetHealthMonitor.Domain.Triages;
using PetHealthMonitor.Unit.Tests.Fixtures;


namespace PetHealthMonitor.Unit.Tests.Services
{

    public class TriageServiceTest
    {

        private readonly ILogger<TriageService> _logger;
        private readonly IPetRepository _petRepository;
        private readonly ITriageService _triageService;
        private readonly IPublishEndpoint _bus;

        public TriageServiceTest()
        {
            _logger = Substitute.For<ILogger<TriageService>>();
            _petRepository = Substitute.For<IPetRepository>();
            _bus = Substitute.For<IPublishEndpoint>();
            _triageService = new TriageService(_logger, _petRepository, _bus);
        }


        [Fact]
        [Trait("Triage", "Pet not found")]

        public async Task Triage_Pet_ShouldReturnNotFoundAsync()
        {
            //Arrange
            TemperatureTriage temperatureFaker = TriageTestFixture.TriageFaker.Generate();
            _petRepository.GetById(Arg.Any<Guid>()).ReturnsNull();

            // Act 
            var exception = await Record.ExceptionAsync(() => _triageService.RecordTriage(temperatureFaker));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<Exception>(exception);
            Assert.Equal("Pet not found.", exception.Message);
        }


        [Fact]
        [Trait("Triage", "Successfully carried out")]

        public void Triage_Pet_ShouldReturnExceptionNull()
        {
            //Arrange
            TemperatureTriage temperatureFaker = TriageTestFixture.TriageFaker.Generate();
            Pet petFaker = PetTestFixture.PetFaker.Generate();
            _petRepository.GetById(Arg.Any<Guid>()).Returns(petFaker);


            //Act
            var response = _triageService.RecordTriage(temperatureFaker);


            //Assert
            Assert.Null(response.Exception);

        }


    }
}
