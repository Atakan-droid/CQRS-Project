using ExampleMediatR.Repositories;
using MediatR;

namespace ExampleMediatR.Models;

public record CreateOrderCommand(string name, decimal price, int customerId) :
    IRequest<Guid>;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order(request.name, request.price, request.customerId);
        var entity = await _orderRepository.CreateOrderAsync(order);
        return entity.Id;
    }
}