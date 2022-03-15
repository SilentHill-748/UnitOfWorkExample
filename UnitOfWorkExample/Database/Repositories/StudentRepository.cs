using Microsoft.EntityFrameworkCore;

using UnitOfWorkExample.Database.Entities;
using UnitOfWorkExample.Database.Repositories.Interfaces;

namespace UnitOfWorkExample.Database.Repositories;

/// <summary>
/// Represents the implementation of <see cref="Repository{TEntity}"/> for <see cref="Student"/> entity.
/// </summary>
public class StudentRepository : Repository<Student>, IStudentRepository
{
    /// <summary>
    /// Initialize <see cref="StudentRepository"/> with database context.
    /// </summary>
    /// <param name="dbContext">Database context of repository.</param>
    public StudentRepository(DbContext dbContext)
        : base(dbContext)
    { }


    public string GetEmail(int studentId)
    {
        Student student = FindById(studentId);
        
        return student.Email is null
            ? string.Empty
            : student.Email;
    }

    public IEnumerable<string> GetEmails()
    {
        var students = Select(includeProperty: null);

        foreach (Student student in students)
        {
            if (student.Email is null)
                yield return string.Empty;
            else
                yield return student.Email;
        }
    }
}