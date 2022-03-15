using Microsoft.EntityFrameworkCore;

using UnitOfWorkExample.Database.Entities;
using UnitOfWorkExample.Database.Repositories.Interfaces;

namespace UnitOfWorkExample.Database.Repositories;

/// <summary>
/// Represents the implementation of <see cref="Repository{TEntity}"/> for <see cref="Group"/> entity.
/// </summary>
public class GroupRepository : Repository<Group>, IGroupRepository
{
    /// <summary>
    /// Initialize <see cref="GroupRepository"/> with database context.
    /// </summary>
    /// <param name="dbContext">Database context of repository.</param>
    public GroupRepository(DbContext dbContext) : base(dbContext) { }
}
