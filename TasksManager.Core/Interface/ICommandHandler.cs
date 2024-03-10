using TasksManager.Core.Command;

namespace TasksManager.Core.Interface;

public interface ICommandHandler<T> where T : CommandBase
{
    Result Handle(T Command);
}