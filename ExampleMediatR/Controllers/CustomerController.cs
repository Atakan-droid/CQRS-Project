using ExampleMediatR.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExampleMediatR.Controllers;

public class CustomerController:ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
}