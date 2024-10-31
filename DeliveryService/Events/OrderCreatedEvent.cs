namespace DeliveryService.Events
{
    public class OrderCreatedEvent
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
