using ExampleMediatR.Models;

namespace ExampleMediatR.Repositories;

public interface ICustomerRepository
{
Task<IdModel> CreateCustomerAsync(Customer customer);
Task<Customer> GetCustomerAsync(Guid id);
Task<Customer> GetCustomerAsync(string email);
Task<IEnumerable<Customer>> GetCustomersAsync();
Task<IdModel> UpdateCustomerAsync(Customer customer);
Task DeleteCustomerAsync(Guid id);

}