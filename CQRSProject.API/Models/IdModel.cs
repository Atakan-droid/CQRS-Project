using Microsoft.AspNetCore.Http.HttpResults;

namespace CQRSProject.API.Models;

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

    public new static IdModel Create(Guid id)
    {
        return new IdModel(id);
    }
}