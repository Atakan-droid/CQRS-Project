using CQRSProject.API.Models;
using Customers.Api.Database;
using Dapper;

namespace CQRSProject.API.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly IDbConnectionFactory _dbContext;

    public OrderRepository(IDbConnectionFactory dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        var db = await _dbContext.CreateConnectionAsync();
        var orders = await db.QueryAsync<Order>(@"SELECT * FROM Orders");
        return orders;
    }

    public async Task<Order> GetOrderAsync(Guid id)
    {
        var db = await _dbContext.CreateConnectionAsync();
        var order = await db.QueryFirstOrDefaultAsync<Order>(@"SELECT * FROM Orders WHERE Id = @Id", new { Id = id });
        return order;
    }

    public async Task<IdModel> CreateOrderAsync(Order order)
    {
        var db = await _dbContext.CreateConnectionAsync();
        await db.ExecuteAsync(
            @"INSERT INTO Orders (Id,Name, Price, Description) VALUES (@Id,@Name, @Price, @Description)", order);
        return new IdModel(order.Id);
    }

    public async Task UpdateOrderAsync(Order order)
    {
        var db = await _dbContext.CreateConnectionAsync();
        await db.ExecuteAsync(
            @"UPDATE Orders SET Name = @Name, CustomerId = @CustomerId, ProductId = @ProductId WHERE Id = @Id", order);
    }

    public async Task DeleteOrderAsync(Guid id)
    {
        var db = await _dbContext.CreateConnectionAsync();
        await db.ExecuteAsync(@"DELETE FROM Orders WHERE Id = @Id", new { Id = id });
    }
}