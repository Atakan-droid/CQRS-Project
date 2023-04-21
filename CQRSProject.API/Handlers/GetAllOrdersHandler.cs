using CQRSProject.API.Models;
using CQRSProject.API.Queries;
using CQRSProject.API.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.API.Handlers;

public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<Order>>
{
    private readonly IOrderRepository _orderRepository;

    public GetAllOrdersHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetOrdersAsync();
        return orders.ToList();
    }
}