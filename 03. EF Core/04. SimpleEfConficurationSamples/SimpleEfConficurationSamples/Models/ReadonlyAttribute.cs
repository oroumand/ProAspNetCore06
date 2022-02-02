using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEfConficurationSamples.Models;
[Keyless]
public class ReadonlyAttribute
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

}

public class ReadonlyFluent
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

}
