using PetHealthMonitor.Domain.Base;

namespace PetHealthMonitor.Domain.Pets
{
    public class Pet : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public string Breed { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Owner { get; set; } = string.Empty;
    }
}
