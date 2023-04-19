using ExampleMediatR.Models;
using MediatR;

namespace ExampleMediatR.Queries;

public class GetOrderByIdQuery:IRequest<Order>
{
    public GetOrderByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get;}
    
}