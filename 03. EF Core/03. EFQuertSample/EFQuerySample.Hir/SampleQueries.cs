using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuerySample.Hir;
public class SampleQueries
{
    private readonly EmpContext _empContext;

    public SampleQueries(EmpContext empContext)
    {
        _empContext = empContext;
    }
    public void AddTypes(int start,int count)
    {
        for (int i = start; i < count; i++)
        {
            var type01 = new Type01
            {
                Name = $"Type01Name{i}"
            };
            type01.Type02s = new List<Type02>();
            for (int j = start; j < count; j++)
            {
                var type02 = new Type02
                {
                    Name = $"Type02Name{i}"
                };
                type02.Type03s = new List<Type03>();
                for (int k = start; k < count; k++)
                {
                    var type03 = new Type03
                    {
                        Name = $"Type03Name{i}"
                    };
                    type02.Type03s.Add(type03);
                }
                type01.Type02s.Add(type02);
            }
            _empContext.Type01s.Add(type01);
        }
        _empContext.SaveChanges();
    }
}
