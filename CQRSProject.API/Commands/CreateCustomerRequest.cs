using MediatR;

namespace CQRSProject.API.Commands;

public class CreateCustomerRequest : IRequest<bool>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public CreateCustomerRequest(string firstName, string lastName, string email, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }
}