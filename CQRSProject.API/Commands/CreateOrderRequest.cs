using MediatR;

namespace CQRSProject.API.Commands;

public class CreateOrderRequest : IRequest<Guid>
{
    public CreateOrderRequest(string name, string description, decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
    }
    
    public decimal Price { get; }
    public string Name { get; }
    public string Description { get; }
}