
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using PetHealthMonitor.Application.Pets;
using PetHealthMonitor.Domain.Pets;
using PetHealthMonitor.Unit.Tests.Fixtures;

namespace PetHealthMonitor.Unit.Tests.Services
{
    public class PetServiceTest
    {
        private readonly IPetService _petService;
        private readonly IPetRepository _petRepository;

        public PetServiceTest()
        {
            _petRepository = Substitute.For<IPetRepository>();
            _petService = new PetService(_petRepository);
        }

        [Fact]
        [Trait("Create", "Create pet with success")]
        public void Create_Pet__ShouldReturnSuccess()
        {
            //Arrange
            Pet createPetFaker = PetTestFixture.CreatePetFaker.Generate();
            Pet petfaker = PetTestFixture.PetFaker.Generate();

            _petRepository.Create(createPetFaker).Returns(petfaker);

            //Act
            Pet? response = _petService.Create(createPetFaker);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(response, petfaker);
        }

        [Fact]
        [Trait("Create", "Tries to breed animal without passing on information")]
        public void Create_Pet_ShouldReturnNull()
        {
            //Arrange
            Pet? createPetFaker = null;

            //Act
            Pet? response = _petService.Create(createPetFaker!);

            //Assert
            Assert.Null(response);
        }

        [Fact]
        [Trait("Read", "Get pet by id with success")]
        public void GetById_Pet_ShouldReturnSuccess()
        {
            //Arrange
            Pet petfaker = PetTestFixture.PetFaker.Generate();

            Guid petId = Arg.Any<Guid>();

            _petRepository.GetById(petId).Returns(petfaker);

            //Act
            Pet? response = _petService.GetById(petId);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(response, petfaker);
        }


        [Fact]
        [Trait("Read", "Try getting pet by id with null return")]
        public void GetById_Pet_ShouldReturnNull()
        {
            //Arrange

            Guid petId = Arg.Any<Guid>();

            _petRepository.GetById(petId).ReturnsNull();

            //Act
            Pet? response = _petService.GetById(petId);

            //Assert
            Assert.Null(response);
        }

    }
}
