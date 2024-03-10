using Microsoft.EntityFrameworkCore;
using TasksManager.Domain.Repository;
using TasksManager.Infrastructure.DataContext;
using Task = TasksManager.Domain.Entity.Task;

namespace TasksManager.Infrastructure.Repository;

public class TaskRepository(TaskContext taskContext) : RepositoryBase<Task>(taskContext), ITaskRepository
{
    private readonly TaskContext _taskContext = taskContext;

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public void Add(Task entity)
    {
        _taskContext.Add(entity);
    }

    public void Update(Task entity)
    {
        _taskContext.Update(entity);
    }

    public int SaveChanges()
    {
        return _taskContext.SaveChanges();
    }

    public async Task<int> AddAsync(Task task)
    {
        _taskContext.Add(task);
        return await _taskContext.SaveChangesAsync();
    }

    public async Task<Task?> GetByIdAsync(long id)
    {
        return await _taskContext.FindAsync<Task>(id);
    }

    public async Task<List<Task>> GetAllAsync()
    {
        return await _taskContext.Set<Task>().ToListAsync();
    }

    public async Task<Task?> ExistsAsync(Task entity)
    {
        return await _taskContext.FindAsync<Task>(entity);
    }
}