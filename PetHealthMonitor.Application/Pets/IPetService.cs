using PetHealthMonitor.Domain.Pets;

namespace PetHealthMonitor.Application.Pets
{
    public interface IPetService
    {
        Pet GetById(Guid id);
        Pet Create(Pet pet);
    }
}
