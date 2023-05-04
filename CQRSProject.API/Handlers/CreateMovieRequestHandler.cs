using System.Net;
using CQRSProject.API.Commands;
using CQRSProject.API.Models;
using CQRSProject.API.Utils;
using MediatR;

namespace CQRSProject.API.Handlers;

public class CreateMovieRequestHandler : IRequestHandler<CreateMovieRequest, Result<Movie, string>>
{
    public async Task<Result<Movie, string>> Handle(CreateMovieRequest request, CancellationToken cancellationToken)
    {
        var movie = new Movie
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            ReleaseDate = request.ReleaseDate,
            Genre = request.Genre,
            Price = request.Price,
            Rating = request.Rating
        };

        return Result<Movie, string>.Success(movie, HttpStatusCode.Created);
    }
}