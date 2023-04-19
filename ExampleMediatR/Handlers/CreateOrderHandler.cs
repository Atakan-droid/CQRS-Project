using ExampleMediatR.Commands;
using ExampleMediatR.Models;
using ExampleMediatR.Repositories;
using MediatR;

namespace ExampleMediatR.Handlers;

public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, Guid>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Guid> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var order = new Order(request.Name, 1, 1);
        await _orderRepository.CreateOrderAsync(order);
        return order.Id;
    }
}
