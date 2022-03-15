using Microsoft.EntityFrameworkCore;

namespace UnitOfWorkExample.Database.Interfaces;

/// <summary>
/// Defines generic unit of work.
/// </summary>
/// <typeparam name="TContext">Type of database context.</typeparam>
public interface IUnitOfWork<TContext> : IUnitOfWork 
    where TContext : DbContext
{
    /// <summary>
    /// Get the database context.
    /// </summary>
    TContext DbContext { get; } 

    /// <summary>
    /// Save changes all <see cref="IUnitOfWork"/>.
    /// </summary>
    /// <param name="unitOfWorks">Collection of <see cref="IUnitOfWork"/>.</param>
    /// <returns>Number of affected objects.</returns>
    Task<int> SaveChangesAsync(params IUnitOfWork[] unitOfWorks);
}
