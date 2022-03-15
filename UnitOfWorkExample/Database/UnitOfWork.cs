using System.Reflection;

using Microsoft.EntityFrameworkCore;

using UnitOfWorkExample.Database.Interfaces;
using UnitOfWorkExample.Database.Repositories;

namespace UnitOfWorkExample.Database;

/// <summary>
/// Represents the object, which implements pattern Unit of Work.
/// </summary>
/// <typeparam name="TContext">Type of database context.</typeparam>
public class UnitOfWork<TContext> : IUnitOfWork<TContext>
    where TContext : DbContext
{
    private Dictionary<Type, object>? _repositories;
    private bool _disposed;


    /// <summary>
    /// Initialize <see cref="UnitOfWork{TContext}"/> with specified database context.
    /// </summary>
    /// <param name="dbContext">Database context for all repositories.</param>
    public UnitOfWork(TContext dbContext)
    {
        DbContext = dbContext;
    }


    public TContext DbContext { get; }


    public object GetRepository<TEntity>()
        where TEntity : class
    {
        if (_repositories is null)
            _repositories = new Dictionary<Type, object>();

        Type entityType = typeof(TEntity);
        if (_repositories.ContainsKey(entityType))
            return _repositories[entityType];

        // Try find type of repository for specified entity.
        var repositoryType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .First(type =>
                type.BaseType is not null &&
                type.BaseType.Equals(typeof(Repository<TEntity>)));

        var repositoryInstance = Activator.CreateInstance(repositoryType, new object[] { DbContext }) ??
            throw new Exception($"Cannot create instance of {repositoryType.Name}!");

        _repositories[entityType] = repositoryInstance;
        return repositoryInstance;
    }

    public int Save()
    {
        return DbContext.SaveChanges();
    }

    public async Task<int> SaveAsync()
    {
        return await DbContext.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync(IUnitOfWork[] unitOfWorks)
    {
        int count = 0;

        foreach (IUnitOfWork unitOfWork in unitOfWorks)
        {
            count += await unitOfWork.SaveAsync();
        }

        count += await SaveAsync();
        return count;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _repositories?.Clear();
                DbContext.Dispose();
            }

            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
