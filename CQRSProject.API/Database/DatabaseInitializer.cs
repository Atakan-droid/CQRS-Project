

using Dapper;

namespace Customers.Api.Database;

public class DatabaseInitializer
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DatabaseInitializer(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task InitializeAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS Customers (
        Id UUID PRIMARY KEY, 
        FirstName TEXT NOT NULL,
        LastName TEXT NOT NULL,
        Email TEXT NOT NULL,
        Phone TEXT NOT NULL
        )");
        await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS Orders (
        Id UUID PRIMARY KEY, 
        [Name] TEXT NOT NULL,
        Description TEXT NOT NULL,
        Price DECIMAL NOT NULL
        )");
    }
}
