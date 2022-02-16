

using EfAdvancedConfigSample.RowVersion;

var context = new RowVersionContext();

var person = context.Person.Find(1);
person.FirstName = "MyNewName";

context.SaveChanges();
