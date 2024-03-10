namespace TasksManager.Core.Entity;

public abstract class Entity : IEntity
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

    public Entity() {
        Id = Convert.ToString(Guid.NewGuid);
        Created = DateTime.Now;
    }
}