using CQRSProject.API.Models;
using MediatR;

namespace CQRSProject.API.Queries;

public class GetOrderByIdQuery:IRequest<Order>
{
    public GetOrderByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get;}
    
    
}