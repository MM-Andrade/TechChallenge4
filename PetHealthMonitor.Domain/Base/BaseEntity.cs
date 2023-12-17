namespace PetHealthMonitor.Domain.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
