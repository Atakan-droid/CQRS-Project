using MediatR;

namespace ExampleMediatR.Commands;

public class CreateOrderRequest : IRequest<Guid>
{
    public CreateOrderRequest(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; }
    public string Description { get; }
}