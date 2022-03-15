namespace UnitOfWorkExample.Database.Entities;

public class Student
{
    public int StudentId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public int Age { get; set; }
    public string? Email { get; set; } = string.Empty;

    public int? GroupId { get; set; }
    public Group? Group { get; set; }
}
