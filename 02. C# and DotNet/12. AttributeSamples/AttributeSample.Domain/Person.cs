using AttributeSamples.CustomAttributes;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
namespace AttributeSample.Domain;

[DebuggerDisplay("Person Name is {FirstName} and his/her age is {Age}")]
[DebuggerTypeProxy(typeof(PersonDebuggerTypeProxy))]
[Serializable]
[CodeChangeHistory("Alireza Oroumand",isBug:false,Description = "Add New Property with Name ...")]
[CodeChangeHistory("Alireza Oroumand", isBug: true, Description = "Fix the bug")]
public class Person
{
    [DebuggerBrowsable(DebuggerBrowsableState.Collapsed)]
    [Required]
    public string FirstName { get; set; }
    [StringLength(100)]
    [CodeChangeHistory("Alireza Oroumand", isBug: false, Description = "Use Attribute in code for property")]
    public string LastName { get; set; }

    public int Age { get; set; }
    [NonSerialized]
    private int _age;   
}
