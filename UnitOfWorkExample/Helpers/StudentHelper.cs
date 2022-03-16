using UnitOfWorkExample.Database.Entities;

namespace UnitOfWorkExample.Helpers;

public static class StudentHelper
{
    public static List<Student> GetStudents()
    {
        int evtGroup = 1;
        int pgsGroup = 2;
        int tcpGroup = 3;

        List<Student> students = new()
        {
            new()
            {
                FirstName = "Олег",
                LastName = "Петров",
                Age = 21,
                Email = "oleg@mail.ru",
                GroupId = evtGroup
            },
            new()
            {
                FirstName = "Михайл",
                LastName = "Орехов",
                Age = 23,
                Email = "max748@rk.ru",
                GroupId = evtGroup
            },
            new()
            {
                FirstName = "Андрей",
                LastName = "Белов",
                Age = 22,
                Email = "beland@gmail.com",
                GroupId = pgsGroup
            },
            new()
            {
                FirstName = "Никита",
                LastName = "Гущев",
                Age = 22,
                Email = "g1sh@gmail.com",
                GroupId = pgsGroup
            },
            new()
            {
                FirstName = "Иван",
                LastName = "Орлов",
                Age = 22,
                Email = "ivanorlov@mail.ru",
                GroupId = pgsGroup
            },
            new()
            {
                FirstName = "Петр",
                LastName = "Петров",
                Age = 21,
                Email = "petya@hmail.com",
                GroupId = tcpGroup
            },
            new()
            {
                FirstName = "Георгий",
                LastName = "Борисов",
                Age = 23,
                Email = "geo.bor@yandex.ru",
                GroupId = tcpGroup
            }
        };

        return students;
    }
}
