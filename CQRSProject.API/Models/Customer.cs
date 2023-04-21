using System.Text.Json.Serialization;

namespace CQRSProject.API.Models;

public class Customer : Entity
{
    public Customer()
    {
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    [JsonIgnore] public string FullName => $"{FirstName} {LastName}";

    public Customer(Guid id) : base(id)
    {
    }
}