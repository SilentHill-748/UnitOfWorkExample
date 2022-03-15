using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text.Json;

using UnitOfWorkExample.Database;
using UnitOfWorkExample.Database.Interfaces;

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
