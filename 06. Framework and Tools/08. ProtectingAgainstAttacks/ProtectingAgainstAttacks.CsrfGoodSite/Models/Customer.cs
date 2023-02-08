namespace ProtectingAgainstAttacks.CsrfGoodSite.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Emtiaz { get; set; }
}

public interface ICustomerRepository
{
    Customer GetCustomer(int id);
    void SetEmtiaz(int customerId, int emtiaz);
}

public class CustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _customers = new List<Customer> 
    { 
        new Customer
        {
            Id= 1,
            Name="Alireza Oroumand",
            Emtiaz = 100
        },
         new Customer
        {
            Id= 2,
            Name="Sajad Abasi",
            Emtiaz = 100
        },
          new Customer
        {
            Id= 3,
            Name="Hamid Saberi",
            Emtiaz = 50
        },
           new Customer
        {
            Id= 4,
            Name="Farid Taheri",
            Emtiaz = 200
        }
    };
    public Customer GetCustomer(int id)
    {
        return _customers.FirstOrDefault(c => c.Id == id);
    }

    public void SetEmtiaz(int customerId, int emtiaz)
    {
        var customer = _customers.FirstOrDefault(c=>c.Id == customerId);
        customer.Emtiaz= emtiaz;
    }
}
