namespace PetHealthMonitor.Domain.Pets
{
    public interface IPetRepository
    {
        Pet GetById(Guid id);
        Pet Create(Pet pet);
    }
}
