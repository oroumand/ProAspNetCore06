using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuerySample.Hir;
public class Employe
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public int? ParentId { get; set; }
    public Employe Parent { get; set; }
    public List<Employe> Children { get; set; }
}
