using CQRSProject.API.Models;
using Customers.Api.Database;
using Dapper;

namespace CQRSProject.API.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly IDbConnectionFactory _dbContext;

    public CustomerRepository(IDbConnectionFactory dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IdModel> CreateCustomerAsync(Customer customer)
    {
        var db = await _dbContext.CreateConnectionAsync();
        db.Execute(
            @"INSERT INTO Customers (Id,FirstName, LastName, Email, Phone) VALUES (@Id,@FirstName, @LastName, @Email, @Phone)",
            customer);
        return new IdModel(customer.Id);
    }

    public async Task<Customer> GetCustomerAsync(Guid id)
    {
        var db = await _dbContext.CreateConnectionAsync();
        var customer =
            await db.QueryFirstOrDefaultAsync<Customer>(@"SELECT * FROM Customers WHERE Id = @Id", new { Id = id });
        return customer;
    }

    public async Task<Customer> GetCustomerAsync(string email)
    {
        var db = await _dbContext.CreateConnectionAsync();
        var customer =
            await db.QueryFirstOrDefaultAsync<Customer>(@"SELECT * FROM Customers WHERE Email = @Email",
                new { Email = email });
        return customer;
    }

    public async Task<List<Customer>> GetCustomersAsync()
    {
        var db = await _dbContext.CreateConnectionAsync();
        var customers = await db.QueryAsync<Customer>(@"SELECT * FROM Customers");
        return customers.ToList();
    }

    public async Task<IdModel> UpdateCustomerAsync(Customer customer)
    {
        var db = await _dbContext.CreateConnectionAsync();
        await db.ExecuteAsync(
            @"UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone WHERE Id = @Id",
            customer);

        return new IdModel(customer.Id);
    }

    public async Task DeleteCustomerAsync(Guid id)
    {
        var db = await _dbContext.CreateConnectionAsync();
        await db.ExecuteAsync(@"DELETE FROM Customers WHERE Id = @Id", new { Id = id });
    }
}