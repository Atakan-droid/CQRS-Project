using ExampleMediatR.Models;
using ExampleMediatR.Queries;
using ExampleMediatR.Repositories;
using MediatR;

namespace ExampleMediatR.Handlers;

public class GetOrderByIdHandler:IRequestHandler<GetOrderByIdQuery, Order>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetOrderAsync(request.Id);
    }
}