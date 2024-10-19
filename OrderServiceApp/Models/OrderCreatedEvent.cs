namespace OrderServiceApp.Models
{
    public class OrderCreatedEvent
    {
        public int OrderId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
