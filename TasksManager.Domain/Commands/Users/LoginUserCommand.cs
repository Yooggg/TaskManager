using TasksManager.Domain.Commands.Base;
using TasksManager.Domain.Entity;

namespace TasksManager.Domain.Commands.Users;

public class LoginUserCommand : UserCommandBase
{
    public string Password { get; set; }
    
    public object Token { get; set; }
}