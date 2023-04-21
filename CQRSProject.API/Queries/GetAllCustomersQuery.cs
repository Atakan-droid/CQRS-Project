using CQRSProject.API.Models;
using MediatR;

namespace CQRSProject.API.Queries;

public class GetAllCustomersQuery: IRequest<List<Customer>>
{
    
}