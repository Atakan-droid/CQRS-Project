using ExampleMediatR.Models;

namespace ExampleMediatR.Repositories;

public class CustomerRepository:ICustomerRepository
{
    private readonly MediatRDbContext _dbContext;

    public CustomerRepository(MediatRDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IdModel> CreateCustomerAsync(Customer customer)
    {
        var db= _dbContext.Customers.Add(customer);
        _dbContext.SaveChanges();
        return Task.FromResult(new IdModel(db.Entity.Id));
    }

    public Task<Customer> GetCustomerAsync(Guid id)
    {
        var db = _dbContext.Customers.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(db);
    }

    public Task<Customer> GetCustomerAsync(string email)
    {
        var db = _dbContext.Customers.FirstOrDefault(x => x.Email == email);
        return Task.FromResult(db);
    }

    public Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        var db = _dbContext.Customers.ToList();
        return Task.FromResult(db.AsEnumerable());
    }

    public Task<IdModel> UpdateCustomerAsync(Customer customer)
    {
        var db = _dbContext.Customers.Update(customer);
        _dbContext.SaveChanges();
        return Task.FromResult(new IdModel(db.Entity.Id));
    }

    public Task DeleteCustomerAsync(Guid id)
    {
        var db = _dbContext.Customers.FirstOrDefault(x => x.Id == id);
        _dbContext.Customers.Remove(db);
        _dbContext.SaveChanges();
        return Task.CompletedTask;
    }
}