namespace CQRSProject.API.Models;

public class Movie
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime ReleaseDate { get; set; }
    public string Genre { get; set; } = null!;
    public decimal Price { get; set; }
    public string Rating { get; set; } = null!;
}