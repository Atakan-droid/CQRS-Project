namespace ExampleMediatR.Models;

public class Order
{
    public Order(string name, decimal price, int customerId)
    {
        Name = name;
        Price = price;
        CustomerId = customerId;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}