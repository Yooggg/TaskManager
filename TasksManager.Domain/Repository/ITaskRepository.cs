using TasksManager.Core.Interface;
using Task = TasksManager.Domain.Entity.Task;

namespace TasksManager.Domain.Repository;

public interface ITaskRepository : IRepository<Task>
{
    Task<int> AddAsync(Task entity);
    Task<Task?> GetByIdAsync(long id);

    Task<List<Entity.Task>> GetAllAsync();
    Task<Task?> ExistsAsync(Task entity);
    
}