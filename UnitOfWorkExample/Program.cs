using UnitOfWorkExample;
using UnitOfWorkExample.Database.Entities;
using UnitOfWorkExample.Database.Repositories.Interfaces;

App.PrintWelcomMessage();

var studentRepository = (IStudentRepository)App.UnitOfWork.GetRepository<Student>();

var allStudents = studentRepository
    .Select(includeProperty: "Group")
    .ToArray();

Console.WriteLine("Print all students.");
App.Print(allStudents);