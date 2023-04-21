using System.Reflection;
using Customers.Api.Database;
using Dapper;
using CQRSProject.API;
using CQRSProject.API.Models;
using CQRSProject.API.PipelineBehaviors;
using CQRSProject.API.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IDbConnectionFactory>(_ =>
    new SqliteConnectionFactory("Data Source=./MediatRSample.db"));
builder.Services.AddTransient<DatabaseInitializer>();


builder.Services.AddEndpointsApiExplorer();

// dapper configuration for storing Guids in SQLite
SqlMapper.AddTypeHandler(new DapperGuidTypeHandler());
SqlMapper.RemoveTypeMap(typeof(Guid));
SqlMapper.RemoveTypeMap(typeof(Guid?));

builder.Services.TryAddScoped<IOrderRepository, OrderRepository>();
builder.Services.TryAddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
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