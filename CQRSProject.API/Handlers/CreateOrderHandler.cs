using CQRSProject.API.Commands;
using CQRSProject.API.Models;
using CQRSProject.API.Repositories;
using MediatR;

namespace CQRSProject.API.Handlers;

public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, Guid>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Guid> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var order = new Order(Guid.NewGuid());
        order.Description = request.Description;
        order.Name = request.Name;
        order.Price = request.Price;
        await _orderRepository.CreateOrderAsync(order);
        return order.Id;
    }
}
