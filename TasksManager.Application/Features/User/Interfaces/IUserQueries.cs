namespace TasksManager.Application.Features.User.Interfaces;

public interface IUserQueries
{
    Task<string> GetTokenByEmailAsync(string email);
    Task<Domain.Entity.User> GetByEmailAsync(string email);
}