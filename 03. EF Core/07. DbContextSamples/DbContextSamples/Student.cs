using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContextSamples;

public interface IAuditable
{
    public DateTime InsertDate { get; set; }
    public DateTime UpdateDate { get; set; }
}
public class Student : IAuditable
{
    public int Id { get; set; }
    public string Name { get; set; }

    public DateTime InsertDate { get; set; }
    public DateTime UpdateDate { get; set; }
}
