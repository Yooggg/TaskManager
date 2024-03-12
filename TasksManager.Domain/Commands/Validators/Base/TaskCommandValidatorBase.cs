using FluentValidation;
using TasksManager.Domain.Commands.Base;
using TasksManager.Domain.Repository;

namespace TasksManager.Domain.Commands.Validators.Base;

public abstract class TaskCommandValidatorBase<T> : AbstractValidator<T> where T : TaskCommandBase
{
    private readonly ITaskRepository _taskRepository;

    protected TaskCommandValidatorBase(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
}