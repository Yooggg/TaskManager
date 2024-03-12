using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TasksManager.Domain.Entity;

namespace TasksManager.Infrastructure.DataContext;

public class IdentityContext : IdentityDbContext<User>
{
    public IdentityContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
}