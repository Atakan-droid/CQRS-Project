using ExampleMediatR.Commands;
using ExampleMediatR.Models;
using ExampleMediatR.Queries;
using ExampleMediatR.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExampleMediatR.Controllers;

public class OrderController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMediator _mediator;

    public OrderController(IOrderRepository orderRepository, IMediator mediator)
    {
        _orderRepository = orderRepository;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var query = new GetAllOrdersQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(Guid id)
    {
        var query = new GetOrderByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] Order order)
    {
        var command = new CreateOrderRequest(order.Name, order.Description);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}