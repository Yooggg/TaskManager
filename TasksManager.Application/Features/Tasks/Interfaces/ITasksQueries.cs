using Task = TasksManager.Domain.Entity.Task;

namespace TasksManager.Application.Features.Tasks.Interfaces;

public interface ITasksQueries
{
    Task<Task?> GetTaskByIdAsync(long id);
    Task<List<Task>> GetAllAsync();
}