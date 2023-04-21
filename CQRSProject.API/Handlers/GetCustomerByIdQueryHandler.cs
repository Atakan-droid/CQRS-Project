using CQRSProject.API.Models;
using CQRSProject.API.Queries;
using CQRSProject.API.Repositories;
using MediatR;

namespace CQRSProject.API.Handlers;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetCustomerAsync(request.Id);
        return customer;
    }
}