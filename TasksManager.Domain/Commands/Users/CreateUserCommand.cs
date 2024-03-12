using TasksManager.Domain.Commands.Base;

namespace TasksManager.Domain.Commands.Users;

public class CreateUserCommand : UserCommandBase
{
    public string Password { get; set; }
    
    public string PasswordConfirmation { get; set; }
}