using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuerySample.Hir;
public class Type01
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Type02> Type02s { get; set; }

}

public class Type02
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Type01Id { get; set; }
    public Type01 Type01 { get; set; }
    public List<Type03> Type03s { get; set; }
}


public class Type03
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Type02Id { get; set; }
    public Type02 Type02 { get; set; }

}