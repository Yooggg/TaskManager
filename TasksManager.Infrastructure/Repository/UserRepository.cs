using Microsoft.AspNetCore.Identity;
using TasksManager.Application.Features.User.Interfaces;
using TasksManager.Domain.Entity;
using TasksManager.Domain.Repository;

namespace TasksManager.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IJwtGenerator _jwtGenerator;
    
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public void Add(User entity)
    {
        throw new NotImplementedException();
    }

    public void Update(User entity)
    {
        throw new NotImplementedException();
    }

    public int SaveChanges()
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistsAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        return user is not null;
    }

    public async Task<string> GetTokenByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var token = _jwtGenerator.CreateToken(user);
        return token;
    }

    public async Task<List<string>> LoginUserAsync(User user)
    {
        List<string> errors = new();
        if (await ExistsAsync(user.Email))
        {
            var localUser = await _userManager.FindByEmailAsync(user.Email);
            var result = await _signInManager.CheckPasswordSignInAsync(localUser, user.Password, false);
            if (result.Succeeded)
            {
                return null;
            }

            var pw = await _userManager.CheckPasswordAsync(localUser, user.Password);
            if (!pw)
            {
                errors.Add("Invalid password");
                return errors;
            }
            
        }
        errors.Add("User with this email doesn't exists");
        return errors;
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }
}