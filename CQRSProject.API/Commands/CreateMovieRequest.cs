using CQRSProject.API.Models;
using CQRSProject.API.Utils;
using MediatR;

namespace CQRSProject.API.Commands;

public class CreateMovieRequest : IRequest<Result<Movie, string>>
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime ReleaseDate { get; set; }
    public string Genre { get; set; } = null!;
    public decimal Price { get; set; }
    public string Rating { get; set; } = null!;
}