using UnitOfWorkExample.Database.Entities;

namespace UnitOfWorkExample.Database.Repositories.Interfaces;

/// <summary>
/// Represents the repository for <see cref="Student"/> entity.
/// </summary>
public interface IStudentRepository : IRepository<Student>
{
    /// <summary>
    /// Get email address of student by primary key value.
    /// </summary>
    /// <param name="studentId">Primary key value.</param>
    /// <returns>Email address of student.</returns>
    string GetEmail(int studentId);

    /// <summary>
    /// Get email address collection of all students.
    /// </summary>
    /// <returns>Email address collection of all students.</returns>
    IEnumerable<string> GetEmails();
}