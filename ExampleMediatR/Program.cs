using System.Reflection;
using Customers.Api.Database;
using ExampleMediatR;
using ExampleMediatR.Models;
using ExampleMediatR.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IDbConnectionFactory>(_ =>
    new SqliteConnectionFactory("Data Source=./MediatRSample.db"));
builder.Services.AddTransient<DatabaseInitializer>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<MediatRDbContext>(options =>
    options.UseSqlite("Data Source=./MediatRSample.db"));
builder.Services.TryAddScoped<IOrderRepository, OrderRepository>();
builder.Services.TryAddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssemblyContaining<Program>());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
await databaseInitializer.InitializeAsync();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();