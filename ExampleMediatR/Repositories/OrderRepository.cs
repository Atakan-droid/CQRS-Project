using ExampleMediatR.Models;

namespace ExampleMediatR.Repositories;

public class OrderRepository:IOrderRepository
{
    private readonly MediatRDbContext _dbContext;

    public OrderRepository(MediatRDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<Order>> GetOrdersAsync(Guid? id)
    {
        var query = _dbContext.Orders.AsQueryable();
        if (id != null)
        {
            query = query.Where(x => x.Id == id);
        }

        var orders = query.AsEnumerable();
        return Task.FromResult(orders);
    }

    public Task<Order> GetOrderAsync(Guid id)
    {
        var db = _dbContext.Orders.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(db);
    }

    public Task<IdModel> CreateOrderAsync(Order order)
    {
        var db = _dbContext.Orders.Add(order);
        _dbContext.SaveChanges();
        return Task.FromResult(new IdModel(db.Entity.Id));
    }

    public Task UpdateOrderAsync(Order order)
    {
        var db = _dbContext.Orders.Update(order);
        _dbContext.SaveChanges();
        return Task.CompletedTask;
    }

    public Task DeleteOrderAsync(Guid id)
    {
        var db = _dbContext.Orders.FirstOrDefault(x => x.Id == id);
        _dbContext.Orders.Remove(db);
        _dbContext.SaveChanges();
        return Task.CompletedTask;
    }
}