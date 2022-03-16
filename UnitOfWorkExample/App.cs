using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text.Json;

using UnitOfWorkExample.Helpers;
using UnitOfWorkExample.Database;
using UnitOfWorkExample.Database.Entities;
using UnitOfWorkExample.Database.Interfaces;
using UnitOfWorkExample.Database.Repositories.Interfaces;

namespace UnitOfWorkExample;

public static class App
{
    /// <summary>
    /// Initialize <see cref="App"/> with the default properties.
    /// </summary>
    static App()
    {
        var dbContextFactory = new AppDbContextFactory();
        UnitOfWork = new UnitOfWork<AppDbContext>(dbContextFactory.CreateDbContext());
    }


    /// <summary>
    /// Get UnitOfWork object.
    /// </summary>
    public static IUnitOfWork<AppDbContext> UnitOfWork { get; }


    /// <summary>
    /// Print welcom message to console.
    /// </summary>
    public static void PrintWelcomMessage()
    {
        Console.WriteLine("Application is running. Hello world!");
    }

    public static void DataSeed()
    {
        //Create database if not exists
        bool wasCreated = UnitOfWork.DbContext.Database.EnsureCreated();

        if (!wasCreated)
            return;
        
        var groupRepo = (IGroupRepository)UnitOfWork.GetRepository<Group>();
        var studentRepo = (IStudentRepository)UnitOfWork.GetRepository<Student>();

        groupRepo.InsertRange(GroupHelper.GetGroups());
        studentRepo.InsertRange(StudentHelper.GetStudents());

        UnitOfWork.Save();
    }

    /// <summary>
    /// Print specified object like json text to console.
    /// </summary>
    /// <param name="obj">Object to be printed.</param>
    public static void Print(object obj)
    {
        if (obj is string strObj)
        {
            Console.WriteLine(strObj);
            return;
        }

        Console.WriteLine($"Type of object: {obj.GetType().Name}");

        JsonSerializerOptions serializeOptions = new()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };

        var serialized = JsonSerializer.Serialize(obj, serializeOptions);
        Console.WriteLine(serialized);
    }
}
