using Microsoft.EntityFrameworkCore;

namespace ExampleMediatR;

public class DbContextFactory
{
    public static MediatRDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MediatRDbContext>();
        optionsBuilder.UseSqlite("Data Source=mediatr.db");
        return new MediatRDbContext(optionsBuilder.Options);
    }
}