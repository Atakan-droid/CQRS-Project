using CQRSProject.API.Models;
using CQRSProject.API.Queries;
using CQRSProject.API.Commands;
using CQRSProject.API.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSProject.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
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
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand order)
    {
        var result = await _mediator.Send(order);
        return Ok(result);
    }
}