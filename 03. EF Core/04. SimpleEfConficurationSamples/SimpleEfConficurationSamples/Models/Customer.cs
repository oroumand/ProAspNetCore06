using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEfConficurationSamples.Models;
public enum CustomerType
{
    Gold,
    Silver
}
public class Customer
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public CustomerType customerType { get; set; }

    public int Age { get; set; }
    public int TempIntWithStringValue { get; set; }
}
