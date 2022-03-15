using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query;

namespace UnitOfWorkExample.Database.Repositories.Interfaces;

/// <summary>
/// Defines generic repository.
/// </summary>
/// <typeparam name="TEntity">Type of Entity.</typeparam>
public interface IRepository<TEntity>
    where TEntity : class
{
    /// <summary>
    /// Add new entity to db context.
    /// </summary>
    /// <param name="entity">Entity to be added.</param>
    void Insert(TEntity entity);

    /// <summary>
    /// Add collection of entities to db context.
    /// </summary>
    /// <param name="entities">Collection of entities to be added.</param>
    void InsertRange(IEnumerable<TEntity> entities);

    /// <summary>
    /// Update specified entity to db context.
    /// </summary>
    /// <param name="entity">Entity to be updated.</param>
    void Update(TEntity entity);

    /// <summary>
    /// Update specified entity collection to db context.
    /// </summary>
    /// <param name="entities">Entity collection to be updated.</param>
    void UpdateRange(IEnumerable<TEntity> entities);

    /// <summary>
    /// Delete specified entity from db context.
    /// </summary>
    /// <param name="entity">Entity to be deleted.</param>
    void Delete(TEntity entity);

    /// <summary>
    /// Delete entity collection from db context.
    /// </summary>
    /// <param name="entities">Entity collection to be deleted.</param>
    void DeleteRange(IEnumerable<TEntity> entities);

    /// <summary>
    /// Find entity by specified primary key value.
    /// </summary>
    /// <param name="id">Primary key value.</param>
    /// <returns>Finded entity.</returns>
    TEntity FindById(object id);

    /// <summary>
    /// Get first entity from db context or null.
    /// </summary>
    /// <returns>If entity collection is not empty then return first entity, else null.</returns>
    TEntity? FirstOrDefault();

    /// <summary>
    /// Get all entities.
    /// </summary>
    /// <param name="predicate">Select condition.</param>
    /// <param name="orderBy">Sort function.</param>
    /// <param name="include">A function to include entities.</param>
    /// <returns>Entity collection contains elements by passed all specified functions.</returns>
    IEnumerable<TEntity> Select(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object?>>? include = null);

    /// <summary>
    /// Get all entities.
    /// </summary>
    /// <param name="predicate">Select condition.</param>
    /// <param name="orderBy">Sort function.</param>
    /// <param name="includeProperty">Property to be included.</param>
    /// <returns>Entity collection contains elements by passed all specified functions.</returns>
    IEnumerable<TEntity> Select(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string? includeProperty = null);
}
