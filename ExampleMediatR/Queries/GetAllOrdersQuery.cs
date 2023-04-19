using ExampleMediatR.Models;
using MediatR;

namespace ExampleMediatR.Queries;

public class GetAllOrdersQuery:IRequest<List<Order>>
{
    public Guid? id { get; set; }
}