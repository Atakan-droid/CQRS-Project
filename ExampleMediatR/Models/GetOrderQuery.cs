using ExampleMediatR.Repositories;
using MediatR;

namespace ExampleMediatR.Models;

public record GetOrderQuery(Guid? id):IRequest<List<Order>>;


public class GetOrderHandler : IRequestHandler<GetOrderQuery, List<Order>>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<Order>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetOrdersAsync(request.id);
        return orders.ToList();
    }
}