using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEfConficurationSamples.Models;
[Table("tbl_car",Schema ="ef2")]
public class Car
{
    public int CarId { get; set; }
    [Column("fld_name")]
    public string CarName { get; set; }
}


public class Train
{
    public int TrainId { get; set; }

    public string TrainName { get; set; }
}
