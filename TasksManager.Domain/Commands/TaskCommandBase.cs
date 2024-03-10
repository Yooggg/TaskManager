using TasksManager.Core.Command;
using TasksManager.Core.Entity;

namespace TasksManager.Domain.Commands;

public class TaskCommandBase :  CommandBase
{
    public string Title { get; set; }
    public string Description { get; set; }
    
}