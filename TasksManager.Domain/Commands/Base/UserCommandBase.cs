using TasksManager.Core.Command;

namespace TasksManager.Domain.Commands.Base;

public class UserCommandBase : CommandBase
{
    public string Email { get; set; }
}