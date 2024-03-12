using TasksManager.Core.Command;

namespace TasksManager.Core.Interface;

public interface ICommandHandlerAsync<T> where T : CommandBase
{
    Task<Result> Handle(T command, CancellationToken cancellationToken);
}