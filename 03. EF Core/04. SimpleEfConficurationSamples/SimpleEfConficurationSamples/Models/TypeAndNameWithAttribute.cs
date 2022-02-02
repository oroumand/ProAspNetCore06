using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SimpleEfConficurationSamples.Models;
public class TypeAndNameWithAttribute
{
    public int Id { get; set; }
    [Column(TypeName ="varchar(50)")]
    [Required]
    public string Name { get; set; }
    public bool IsValid { get; set; }
    [Precision(14,4)]
    public Decimal Price { get; set; }
    [Unicode(false)]
    [MaxLength(10)]
    public string Code { get; set; }

}

public class TypeAndNameWithFluent
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsValid { get; set; }
    public Decimal Price { get; set; }
    public string Code { get; set; }

}
