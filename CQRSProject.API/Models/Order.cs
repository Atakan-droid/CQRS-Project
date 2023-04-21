namespace CQRSProject.API.Models;

public class Order : Entity
{
    public Order(Guid id) : base(id)
    {
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public Order()
    {
    }
}