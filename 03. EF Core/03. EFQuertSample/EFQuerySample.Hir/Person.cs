using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuerySample.Hir;
public class Person
{
    private readonly ILazyLoader _lazyLoader;
    private readonly Action<object, string> _action;

    //public Person(string firstName, int age)
    //{
    //    FirstName = "Firstname is: "+firstName ;
    //    LastName = "My LastName";
    //}
    //public Person(ILazyLoader lazyLoader)
    //{
    //    _lazyLoader = lazyLoader;
    //}
    //public Person(Action<object,string> action)
    //{
    //    _action = action;
    //}
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set;}
    //private List<Address> _addresses;
    //public List<Address> Addresses { get=> _lazyLoader.Load(this, ref _addresses); set=>_addresses = value; }

    public List<Address> Addresses { get; set; }    

    }
public class Address
{
    public int Id { get; set; }
    public string City { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
}
