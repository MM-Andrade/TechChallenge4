using Bogus;
using PetHealthMonitor.Domain.Triages;

namespace PetHealthMonitor.Unit.Tests.Fixtures
{
    public class TriageTestFixture
    {
        public static Faker<TemperatureTriage> TriageFaker { get; } = new Faker<TemperatureTriage>()
            .RuleFor(triage => triage.Temperature, fake => fake.Random.Double())
            .RuleFor(triage => triage.Observations, fake => fake.Lorem.Text())
            .RuleFor(triage => triage.PetId, Guid.NewGuid());
       
    }
}
