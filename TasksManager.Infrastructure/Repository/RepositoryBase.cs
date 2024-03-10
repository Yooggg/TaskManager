using TasksManager.Core.Entity;
using TasksManager.Core.Interface;
using TasksManager.Infrastructure.DataContext;

namespace TasksManager.Infrastructure.Repository;

public class RepositoryBase<T> : IRepository<T> where T : IEntity
{
    private readonly TaskContext _tasksContext;

    public RepositoryBase(TaskContext tasksContext)
    {
        _tasksContext = tasksContext;
    }

    public void Dispose()
    {
        _tasksContext.Dispose();
        GC.SuppressFinalize(this);
    }

    public void Add(T entity)
    {
        _tasksContext.Add(entity);
    }

    public void Update(T entity)
    {
        _tasksContext.Update(entity);
    }

    public int SaveChanges()
    {
        return _tasksContext.SaveChanges();
    }
}