using FluentValidation;

namespace TasksManager.Core.Command;

public abstract class CommandHandlerBase
{
    private IEnumerable<string> Notifications;

    public FluentValidation.Results.ValidationResult Validate<T, TValidator>(
        T command,
        TValidator validator)
        where T : CommandBase
        where TValidator : IValidator<T>
    {
        var validationResult = validator.Validate(command);
        Notifications = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

        return validationResult;
    }

    public Result Return()
    {
        return new Result(!Notifications.Any(), Notifications);
    } 
}