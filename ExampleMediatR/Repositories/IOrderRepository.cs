using ExampleMediatR.Models;

namespace ExampleMediatR.Repositories;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetOrdersAsync(Guid? id);
    Task<Order> GetOrderAsync(Guid id);
    Task<IdModel> CreateOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(Guid id);
}