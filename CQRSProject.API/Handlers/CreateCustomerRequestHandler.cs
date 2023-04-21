using CQRSProject.API.Commands;
using CQRSProject.API.Models;
using CQRSProject.API.Repositories;
using MediatR;

namespace CQRSProject.API.Handlers;

public class CreateCustomerRequestHandler : IRequestHandler<CreateCustomerRequest, bool>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerRequestHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<bool> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = new Customer(Guid.NewGuid());
        customer.FirstName = request.FirstName;
        customer.LastName = request.LastName;
        customer.Email = request.Email;
        customer.Phone = request.Phone;

        var result = await _customerRepository.CreateCustomerAsync(customer);
        return result.Id != Guid.Empty;
    }
}