namespace EfCore.RelationConfiguraitonSample.SimpleConventionSample;
public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class Address
{
    public int Id { get; set; }
    public string Citry { get; set; }
    public Person? Person { get; set; }
    //public int? PersonId { get; set; }
}
