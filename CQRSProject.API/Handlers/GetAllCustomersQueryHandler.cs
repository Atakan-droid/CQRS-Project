using CQRSProject.API.Models;
using CQRSProject.API.Queries;
using CQRSProject.API.Repositories;
using MediatR;

namespace CQRSProject.API.Handlers;

public class GetAllCustomersQueryHandler: IRequestHandler<GetAllCustomersQuery, List<Customer>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<List<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        return await _customerRepository.GetCustomersAsync();
    }
}
