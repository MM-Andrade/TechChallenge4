using PetHealthMonitor.Domain.Pets;

namespace PetHealthMonitor.Application.Pets
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public Pet Create(Pet pet)
        {
            if (pet is null)
                return null;

            return _petRepository.Create(pet);
        }
        public Pet GetById(Guid id)
        {
            var pet = _petRepository.GetById(id);

            if (pet is not null)
            {
                return pet;
            }

            return null;
        }
    }
}
