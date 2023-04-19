using ExampleMediatR.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleMediatR;

public class MediatRDbContext:DbContext
{
    public MediatRDbContext(DbContextOptions<MediatRDbContext> options):base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
}
