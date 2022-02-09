
//using EfCore.RelationConfiguraitonSample.TPTSamples;

//TpTContext ctx = new TpTContext();

//var student = new Student
//{
//    FirstName = "S01",
//    LastName = "LS01",
//    StudentNumebr = "123"
//};
//var teacher = new Teacher
//{
//    FirstName = "T01",
//    LastName = "LT01",
//    TeacherNumber = "123"
//};
//ctx.Add(student);
//ctx.Add(teacher);
//ctx.SaveChanges();


//var people = ctx.People.ToList();

//var s = ctx.People.OfType<Student>().ToList();  
//var t = ctx.People.OfType<Teacher>().ToList();
//Console.ReadLine();


using EfCore.RelationConfiguraitonSample.TableSplittingSamples;
using Microsoft.EntityFrameworkCore;

NewsContext context = new NewsContext();
//NewsSummry ns = new NewsSummry
//{
//    imageUrl = "URL",
//    ShortDescription = "Description",
//    Title = "Title",
//    NewsDetail = new NewsDetail
//    {
//        Body = "Body"
//    }
//};

//context.Add(ns);


//context.SaveChanges();
//
var newslist = context.NewsSummries.Include(c=>c.NewsDetail).ToList();
Console.ReadLine();