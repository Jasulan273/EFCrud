using System;
using MassTransit;
using DeliveryService.Events;
using System.Threading.Tasks;

namespace DeliveryService.Consumers
{
    public class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
    {
        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var order = context.Message;
            Console.WriteLine($"Received order for delivery: Id = {order.Id}, Name = {order.Name}, Description = {order.Description}");
        }
    }
}
