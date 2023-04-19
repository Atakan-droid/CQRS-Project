using Microsoft.AspNetCore.Http.HttpResults;

namespace ExampleMediatR.Models;

public class IdModel<T>
{
    public IdModel(T id)
    {
        Id = id;
    }

    public T Id { get; }

    public static IdModel<T> Create(T id)
    {
        return new IdModel<T>(id);
    }

}

public class IdModel:IdModel<Guid>
{
    public IdModel(Guid id):base(id)
    {
    }

    public static IdModel Create(Guid id)
    {
        return new IdModel(id);
    }
}