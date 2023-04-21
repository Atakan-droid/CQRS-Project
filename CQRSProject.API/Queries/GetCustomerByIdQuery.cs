using CQRSProject.API.Models;
using MediatR;

namespace CQRSProject.API.Queries;

public class GetCustomerByIdQuery : IRequest<Customer>
{
    public Guid Id;

    public GetCustomerByIdQuery(Guid id)
    {
        Id = id;
    }
}