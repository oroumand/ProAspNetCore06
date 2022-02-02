using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEfConficurationSamples.Models;
[Index(nameof(Name),IsUnique =true,Name ="ix_Name_Using_Attribute")]
public class IndexUsingAttribute
{
    public int Id { get;set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class IndexUsingFluent
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Filtered { get; set; }
}
