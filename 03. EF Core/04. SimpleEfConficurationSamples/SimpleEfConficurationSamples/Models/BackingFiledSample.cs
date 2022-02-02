using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEfConficurationSamples.Models;
public class BackingFiledSample
{
    public int Id { get; set; }
    private int _fatherNameField;

    public int FatherName
    {
        get { return _fatherNameField; }
        set { _fatherNameField = value; }
    }

}
