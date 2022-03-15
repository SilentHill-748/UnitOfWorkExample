using System.Linq.Expressions;
using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using UnitOfWorkExample.Database.Repositories.Interfaces;

namespace UnitOfWorkExample.Database.Repositories;

/// <summary>
/// Represents the implementation of <see cref="IRepository{TEntity}"/>.
/// </summary>
/// <typeparam name="TEntity">Type of entity.</typeparam>
public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    private readonly DbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;


    /// <summary>
    /// Initialize <see cref="Repository{TEntity}"/> with database context.
    /// </summary>
    /// <param name="context">Database context of repository.</param>
    /// <exception cref="ArgumentNullException"/>
    public Repository(DbContext context)
    {
        _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = context.Set<TEntity>();
    }


    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public IEnumerable<TEntity> Select(
        Expression<Func<TEntity, bool>>? predicate = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object?>>? include = null)
    {
        IQueryable<TEntity> query = _dbSet;

        if (include is not null) 
            query = include(query);

        if (predicate is not null) 
            query = query.Where(predicate);

        if (orderBy is not null) 
            query = orderBy(query);

        return query;
    }

    public IEnumerable<TEntity> Select(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string? includeProperty = null)
    {
        IQueryable<TEntity> query = _dbSet;

        if (predicate is not null)
            query = query.Where(predicate);

        if (!string.IsNullOrEmpty(includeProperty))
            query = query.Include(includeProperty);

        if (orderBy is not null)
            query = orderBy(query);

        return query;
    }

    public TEntity FindById(object id)
    {
        TEntity? entity = _dbSet.Find(id); // Почему калабонга так не сделал?

        if (entity is null)
            throw new Exception("Entity at specified id isn't contains in database.");

        typeof(TEntity).GetTypeInfo();

        return entity;
    }

    public TEntity? FirstOrDefault() =>
        _dbSet.FirstOrDefault();

    public void Insert(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public void InsertRange(IEnumerable<TEntity> entities)
    {
        _dbSet.AddRange(entities);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        _dbSet.UpdateRange(entities);
    }
}
