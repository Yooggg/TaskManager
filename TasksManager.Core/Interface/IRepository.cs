using TasksManager.Core.Entity;

namespace TasksManager.Core.Interface;

public interface IRepository<T> : IDisposable where T : IEntity
{
    void Add(T entity);
    void Update(T entity);
    
    int SaveChanges();
}