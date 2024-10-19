using MassTransit;
using OrderServiceApp.Data;
using OrderServiceApp.Models;
using OrderServiceApp.Controllers.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace OrderServiceApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderContext _context;
        private readonly IBus _bus;

        public OrderService(OrderContext context, IBus bus)
        {
            _context = context;
            _bus = bus;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            var orderCreatedEvent = new OrderCreatedEvent
            {
                OrderId = order.Id,
                Name = order.Name,
                Description = order.Description
            };

            await _bus.Publish(orderCreatedEvent);

            return order;
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task UpdateOrderAsync(int id, Order order)
        {
            var existingOrder = await _context.Orders.FindAsync(id);
            if (existingOrder == null)
            {
                throw new ArgumentException("Order not found");
            }

            existingOrder.Name = order.Name;
            existingOrder.Description = order.Description;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}
