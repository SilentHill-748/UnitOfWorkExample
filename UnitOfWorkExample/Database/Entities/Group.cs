namespace UnitOfWorkExample.Database.Entities;

public class Group
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = string.Empty;

    public List<Student> Students { get; set; } = new();
}
