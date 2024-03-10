using TasksManager.Application.Features.Tasks.Interfaces;
using TasksManager.Domain.Repository;
using Task = TasksManager.Domain.Entity.Task;

namespace TasksManager.Application.Features.Tasks.Queries;

public class TaskQueries : ITasksQueries
{
    private readonly ITaskRepository _taskRepository;

    public TaskQueries(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<Task?> GetTaskByIdAsync(long id)
    {
        return await _taskRepository.GetByIdAsync(id);
    }

    public async Task<List<Task>> GetAllAsync()
    {
        return await _taskRepository.GetAllAsync();
    }
}