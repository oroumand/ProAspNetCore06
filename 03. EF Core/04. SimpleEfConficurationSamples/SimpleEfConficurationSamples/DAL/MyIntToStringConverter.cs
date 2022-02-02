using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEfConficurationSamples.DAL;
public class MyIntToStringConverter : ValueConverter<int, string>
{
    public MyIntToStringConverter() : base(c=> c.ToString(), c=> int.Parse(c))
    {
    }

   
}
