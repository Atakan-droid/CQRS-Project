using CQRSProject.API.Commands;
using CQRSProject.API.Repositories;
using CQRSProject.API.Models;
using MediatR;

namespace CQRSProject.API.Handlers;

public class UpdateCustomerRequestHandler : IRequestHandler<UpdateCustomerRequest, bool>
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerRequestHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<bool> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
    {

        var customer = await _customerRepository.GetCustomerAsync(request.Id);
        customer.FirstName = request.FirstName;
        customer.LastName = request.LastName;
        customer.Email = request.Email;
        customer.Phone = request.Phone;
        
        var result = await _customerRepository.UpdateCustomerAsync(customer);
        return result.Id != Guid.Empty;
    }
}