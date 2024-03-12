using TasksManager.Core.Interface;
using TasksManager.Domain.Entity;

namespace TasksManager.Domain.Repository;

public interface IUserRepository : IRepository<User>
{
    
    Task<bool> AddAsync(User user);

    Task<bool> ExistsAsync(string email);

    Task<string> GetTokenByEmailAsync(string email);

    Task<List<string>> LoginUserAsync(User user);

    Task<User> GetByEmailAsync(string email);
}