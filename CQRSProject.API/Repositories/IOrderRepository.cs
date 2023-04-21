using CQRSProject.API.Models;

namespace CQRSProject.API.Repositories;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task<Order> GetOrderAsync(Guid id);
    Task<IdModel> CreateOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(Guid id);
}