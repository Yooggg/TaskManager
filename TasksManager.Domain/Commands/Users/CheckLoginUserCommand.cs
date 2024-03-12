using TasksManager.Domain.Commands.Base;
using TasksManager.Domain.Entity;

namespace TasksManager.Domain.Commands.Users;

public class CheckLoginUserCommand : UserCommandBase
{
    public string Token { get; set; }
}