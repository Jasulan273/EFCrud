using OrderServiceApp.Models;

namespace OrderServiceApp.Controllers.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<Order?> GetOrderByIdAsync(int id);
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task UpdateOrderAsync(int id, Order order);
        Task DeleteOrderAsync(int id);
    }
}
