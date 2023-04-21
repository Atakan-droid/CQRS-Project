using CQRSProject.API.Repositories;
using MediatR;

namespace CQRSProject.API.Models;

public record CreateOrderCommand(string name, decimal price, string description) :
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
        var order = new Order(Guid.NewGuid());
        order.Description = request.description;
        order.Name = request.name;
        order.Price = request.price;
        
        var entity = await _orderRepository.CreateOrderAsync(order);
        return entity.Id;
    }
}