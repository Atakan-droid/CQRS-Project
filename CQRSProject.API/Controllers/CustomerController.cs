using CQRSProject.API.Attribute;
using CQRSProject.API.Commands;
using CQRSProject.API.Identity;
using CQRSProject.API.Models;
using CQRSProject.API.Queries;
using CQRSProject.API.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRSProject.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        var query = new GetAllCustomersQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(Guid id)
    {
        var query = new GetCustomerByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
    {
        var command = new CreateCustomerRequest(customer.FirstName, customer.LastName, customer.Email, customer.Phone);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    //when not matches returns ,403 Forbidden if auhorized
    [HttpPut]
    [Authorize]
    [RequiresClaim(IdentityData.AdminUserClaimName, "true")]

    public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
    {
        var command = new UpdateCustomerRequest(customer.Id, customer.FirstName, customer.LastName, customer.Email,
            customer.Phone);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}