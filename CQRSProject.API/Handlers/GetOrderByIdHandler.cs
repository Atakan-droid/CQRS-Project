using CQRSProject.API.Models;
using CQRSProject.API.Queries;
using CQRSProject.API.Repositories;
using MediatR;

namespace CQRSProject.API.Handlers;

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