using TasksManager.Core.Entity;

namespace TasksManager.Domain.Entity;

public class Task : IEntity
{
    public long TaskId { get; set; }
    public string Title { get; set; }
    
    public string Description { get; set; }
    public string Details { get; set; }

    public Task(string title, string details)
    {
        Title = title;
        Details = details;
    }

    public Task()
    {
    }

    public string Id { get; set; }
}