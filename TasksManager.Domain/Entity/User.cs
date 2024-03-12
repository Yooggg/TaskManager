using Microsoft.AspNetCore.Identity;
using TasksManager.Core.Entity;

namespace TasksManager.Domain.Entity;

public class User : IdentityUser, IEntity
{
    public string Password;

    public string Token;
    
    string IEntity.Id
    {
        get => Id;
        set => Id = value;
    }
}