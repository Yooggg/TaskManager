using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TasksManager.Application.Features.Tasks.Commands;
using TasksManager.Application.Features.Tasks.Interfaces;
using TasksManager.Application.Features.Tasks.Queries;
using TasksManager.Core.Command;
using TasksManager.Core.Interface;
using TasksManager.Domain.Commands;
using TasksManager.Domain.Commands.Tasks;
using TasksManager.Domain.Commands.Validators;
using TasksManager.Domain.Commands.Validators.Task;
using TasksManager.Domain.Repository;
using TasksManager.Infrastructure.DataContext;
using TasksManager.Infrastructure.Repository;
using Task = TasksManager.Domain.Entity.Task;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();

// Database connection
builder.Services.AddDbContext<TaskContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("TasksConnection")));

// // For Identity
// builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//     .AddEntityFrameworkStores<FOAContext>()
//     .AddDefaultTokenProviders();
//
// // Adding Authentication
// builder.Services.AddAuthentication(options =>
//     {
//         options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//         options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//         options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//     })
// // Adding Jwt Bearer
//     .AddJwtBearer(options =>
//     {
//         options.SaveToken = true;
//         options.RequireHttpsMetadata = false;
//         options.TokenValidationParameters = new TokenValidationParameters()
//         {
//             ValidateIssuer = true,
//             ValidateAudience = true,
//             ValidAudience = configuration["JWT:ValidAudience"],
//             ValidIssuer = configuration["JWT:ValidIssuer"],
//             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
//         };
//     });

// Adding repository
builder.Services.AddScoped<IValidator<CreateTaskCommand>, CreateTaskCommandValidator>();
builder.Services.AddScoped<IRequestHandler<CreateTaskCommand, Result>, CreateTaskCommandHandler>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITasksQueries, TaskQueries>();
builder.Services.AddTransient<TaskRepository>();

// Adding MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();