using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEfConficurationSamples.Models;
public class PrimaryKeyAttribute
{
    [Key]
    public int MyPrimaryKey { get; set; }
    public string Name { get; set; }

}
public class PrimaryKeyFluent
{

    public int Pk01 { get; set; }
    public int Pk02 { get; set; }
    public string Name { get; set; }

}