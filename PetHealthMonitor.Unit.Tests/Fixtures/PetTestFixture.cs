using Bogus;
using PetHealthMonitor.Domain.Pets;

namespace PetHealthMonitor.Unit.Tests.Fixtures
{
    public class PetTestFixture
    {
        public static Faker<Pet> PetFaker { get; } = new Faker<Pet>()
            .RuleFor(pet => pet.Id, fake => Guid.NewGuid())
            .RuleFor(pet => pet.Name, fake => fake.Name.FullName())
            .RuleFor(pet => pet.Owner, fake => fake.Name.FullName())
            .RuleFor(pet => pet.Breed, fake => fake.Random.Word())
            .RuleFor(pet => pet.DateOfBirth, fake => fake.Person.DateOfBirth)
            .RuleFor(pet => pet.Species, fake => fake.Random.Word())
            .RuleFor(pet => pet.CreatedAt, fake => fake.Date.Recent(0));

        public static Faker<Pet> CreatePetFaker { get; } = new Faker<Pet>()
            .RuleFor(pet => pet.Name, fake => fake.Name.FullName())
            .RuleFor(pet => pet.Owner, fake => fake.Name.FullName())
            .RuleFor(pet => pet.Breed, fake => fake.Random.Word())
            .RuleFor(pet => pet.DateOfBirth, fake => fake.Person.DateOfBirth)
            .RuleFor(pet => pet.Species, fake => fake.Random.Word());

    }
}
