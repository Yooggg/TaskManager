using TasksManager.Application.Features.User.Interfaces;
using TasksManager.Domain.Repository;

namespace TasksManager.Application.Features.User.Queries;

public class UserQueries : IUserQueries
{
    private readonly IUserRepository _userRepository;

    public UserQueries(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> GetTokenByEmailAsync(string email)
    {
        return await _userRepository.GetTokenByEmailAsync(email);
    }

    public async Task<Domain.Entity.User> GetByEmailAsync(string email)
    {
        return await _userRepository.GetByEmailAsync(email);
    }
}