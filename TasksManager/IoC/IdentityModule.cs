using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TasksManager.Application.Features.User.CommandHadlers;
using TasksManager.Application.Features.User.Interfaces;
using TasksManager.Application.Features.User.Queries;
using TasksManager.Core.Interface;
using TasksManager.Domain.Commands.Users;
using TasksManager.Domain.Commands.Validators.User;
using TasksManager.Domain.Repository;
using TasksManager.Infrastructure.DataContext;
using TasksManager.Infrastructure.Repository;
using TasksManager.Infrastructure.Security;

namespace TasksManager.IoC;

public static class IdentityModule
{
    public static void Register(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        // Validators.
        services.AddScoped<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
        services.AddScoped<IValidator<LoginUserCommand>, LoginUserCommandValidator>();
        // Commands.
        services.AddScoped<ICommandHandlerAsync<CreateUserCommand>, CreateUserCommandHandler>();
        services.AddScoped<ICommandHandlerAsync<LoginUserCommand>, LoginUserCommandHandler>();
        //Queries.
        services.AddScoped<IUserQueries, UserQueries>();
        // Security.
        services.AddScoped<IJwtGenerator, JwtGenerator>();
        services.AddSingleton<JwtValidator>();
    }
    
    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        services.AddDbContext<IdentityContext>(options =>
            options.UseNpgsql(connectionString));
    }
}