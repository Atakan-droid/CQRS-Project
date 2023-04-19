using ExampleMediatR.Models;
using ExampleMediatR.Queries;
using ExampleMediatR.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExampleMediatR.Handlers;

public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<Order>>
{
    private readonly IOrderRepository _orderRepository;

    public GetAllOrdersHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetOrdersAsync(request.id);
        return orders.ToList();
    }
}