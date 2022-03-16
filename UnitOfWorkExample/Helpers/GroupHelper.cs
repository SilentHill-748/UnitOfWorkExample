using UnitOfWorkExample.Database.Entities;

namespace UnitOfWorkExample.Helpers;

public static class GroupHelper
{
    /// <summary>
    /// Get group collection for add to database.
    /// </summary>
    /// <returns>Groups collection.</returns>
    public static List<Group> GetGroups()
    {
        List<Group> groups = new()
        {
            new Group() { GroupName = "ЭВТ-19-1б" },
            new Group() { GroupName = "ПГС-19-1б" },
            new Group() { GroupName = "ТЦП-19-1б" }
        };

        return groups;
    }
}
