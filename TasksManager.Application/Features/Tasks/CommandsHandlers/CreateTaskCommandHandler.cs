using FluentValidation;
using MediatR;
using TasksManager.Core.Command;
using TasksManager.Domain.Commands;
using TasksManager.Domain.Commands.Tasks;
using TasksManager.Domain.Repository;

namespace TasksManager.Application.Features.Tasks.Commands;

public class CreateTaskCommandHandler : CommandHandlerBase, IRequestHandler<CreateTaskCommand, Result>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IValidator<CreateTaskCommand> _createTaskCommandValidator;

    public CreateTaskCommandHandler(ITaskRepository taskRepository, IValidator<CreateTaskCommand> createTaskCommandValidator)
    {
        _taskRepository = taskRepository;
        _createTaskCommandValidator = createTaskCommandValidator;
    }

    public async Task<Result> Handle(CreateTaskCommand command, CancellationToken cancellationToken)
    {
        var validationResult = Validate(command, _createTaskCommandValidator);
        
        if (validationResult.IsValid)
        {
            Domain.Entity.Task task = new()
            {
                Title = command.Title,
                Description = command.Description
            };
            await _taskRepository.AddAsync(task);
        }

        return Return();
    }
}