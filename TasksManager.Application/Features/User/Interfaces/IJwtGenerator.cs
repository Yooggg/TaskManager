namespace TasksManager.Application.Features.User.Interfaces;

public interface IJwtGenerator
{
    string CreateToken(Domain.Entity.User user);
}