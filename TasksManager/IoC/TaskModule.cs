using FluentValidation;
using MediatR;
using TasksManager.Application.Features.Tasks.Commands;
using TasksManager.Application.Features.Tasks.Interfaces;
using TasksManager.Application.Features.Tasks.Queries;
using TasksManager.Core.Command;
using TasksManager.Domain.Commands.Tasks;
using TasksManager.Domain.Commands.Validators.Task;
using TasksManager.Domain.Repository;
using TasksManager.Infrastructure.Repository;

namespace TasksManager.IoC;

public static class TaskModule
{
    public static void Register(this IServiceCollection services)
    {   // Validators.
        services.AddScoped<IValidator<CreateTaskCommand>, CreateTaskCommandValidator>();
        
        services.AddScoped<IRequestHandler<CreateTaskCommand, Result>, CreateTaskCommandHandler>();
        services.AddScoped<ITaskRepository, TaskRepository>();
        
        //Queries.
        services.AddScoped<ITasksQueries, TaskQueries>();
        services.AddTransient<TaskRepository>();
    }
}