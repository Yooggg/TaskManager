using FluentValidation;
using TasksManager.Domain.Commands.Tasks;
using TasksManager.Domain.Commands.Validators.Base;
using TasksManager.Domain.Repository;

namespace TasksManager.Domain.Commands.Validators.Task;

public class CreateTaskCommandValidator : TaskCommandValidatorBase<CreateTaskCommand>
{
    private readonly ITaskRepository _taskRepository;
    
    public CreateTaskCommandValidator(ITaskRepository taskRepository) : base(taskRepository)
    {
        _taskRepository = taskRepository;
    }

    private void ValidateTitle()
    {
        RuleFor(taskCommand => taskCommand.Title).NotEmpty();
    }
    
    private void ValidateDescription()
    {
        RuleFor(taskCommand => taskCommand.Description).NotEmpty();
    }
}