using System.Reflection;

using Microsoft.EntityFrameworkCore;

using UnitOfWorkExample.Database.Entities;

namespace UnitOfWorkExample.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }


    public DbSet<Student> Students => Set<Student>();

    public DbSet<Group> Groups => Set<Group>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
