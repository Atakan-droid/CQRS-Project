using CQRSProject.API.Models;
using MediatR;

namespace CQRSProject.API.Queries;

public class GetAllOrdersQuery:IRequest<List<Order>>
{
}