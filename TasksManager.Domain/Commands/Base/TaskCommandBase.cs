using TasksManager.Core.Command;

namespace TasksManager.Domain.Commands.Base;

public class TaskCommandBase :  CommandBase
{
    public string Title { get; set; }
    public string Description { get; set; }
    
}