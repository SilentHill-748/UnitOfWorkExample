namespace UnitOfWorkExample.Database.Interfaces;

/// <summary>
/// Defines unit of work.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Get custom repository by specified entity type.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity.</typeparam>
    /// <returns>Custom repository of specified entity.</returns>
    object GetRepository<TEntity>() where TEntity: class;

    /// <summary>
    /// Synchronously save changes.
    /// </summary>
    /// <returns>Number of affected objects.</returns>
    int Save();

    /// <summary>
    /// Asynchronously save changes.
    /// </summary>
    /// <returns>Number of affected objects</returns>
    Task<int> SaveAsync();
}
