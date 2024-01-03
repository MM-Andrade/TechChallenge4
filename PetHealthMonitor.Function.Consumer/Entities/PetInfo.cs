namespace PetHealthMonitor.Function.Consumer.Entities
{
    public class PetInfo
    {
        public Guid PetId { get; set; }
        public int Temperature { get; set; }
        public string Observation { get; set; }
    }
}
