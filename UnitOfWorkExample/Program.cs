using UnitOfWorkExample;
using UnitOfWorkExample.Database.Entities;
using UnitOfWorkExample.Database.Repositories.Interfaces;

App.PrintWelcomMessage();
App.DataSeed();

var studentRepo = (IStudentRepository)App.UnitOfWork.GetRepository<Student>();
var allStudents = studentRepo
    .Select(includeProperty: "Group")
    .ToArray();

App.Print(allStudents);