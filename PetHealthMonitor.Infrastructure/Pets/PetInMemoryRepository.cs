using PetHealthMonitor.Domain.Pets;

namespace PetHealthMonitor.Infrastructure.Pets
{
    public class PetInMemoryRepository : IPetRepository
    {
        private readonly List<Pet> _pets = new List<Pet>();

        public Pet Create(Pet pet)
        {
            _pets.Add(pet);

            return pet;
        }

        public Pet GetById(Guid id)
        {
            var pet = _pets.FirstOrDefault(pet => pet.Id == id);
            return pet ?? new Pet();
        }
    }
}
