namespace CQRSProject.API.Models;

public abstract class Entity<T>
{
    public T Id { get; set; }

    public Entity(T id)
    {
        Id = id;
    }

    public Entity()
    {
        
    }
    

}

public abstract class Entity : Entity<Guid>
{
    public Entity(Guid id) : base(id)
    {
    }

    public Entity()
    {
        
    }
    
}