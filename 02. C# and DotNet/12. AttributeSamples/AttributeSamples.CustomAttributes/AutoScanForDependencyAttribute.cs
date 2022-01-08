using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeSamples.CustomAttributes;
[AttributeUsage(AttributeTargets.Assembly)]
public class AutoScanForDependencyAttribute:Attribute
{
}
[AttributeUsage(AttributeTargets.Class| AttributeTargets.Interface| AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Property,AllowMultiple =true,Inherited =false)]
public class CodeChangeHistoryAttribute : Attribute
{
    private readonly string _author;

    public string Description { get; set; }
    public DateTime ChangeDateTime { get; set; }
    public bool IsBug { get; }

    public CodeChangeHistoryAttribute(string author,bool isBug=false)
    {
        _author = author;
        IsBug = isBug;
    }
}
