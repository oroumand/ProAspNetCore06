using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContextSamples;
public class Course : INotifyPropertyChanged, INotifyPropertyChanging
{
    public event PropertyChangingEventHandler? PropertyChanging;
    public event PropertyChangedEventHandler? PropertyChanged;

    private int id;

    public int Id
    {
        get { return id; }
        set {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(Name)));

            id = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));

        }
    }

    private string name;

    public string Name
    {
        get { return name; }
        set {
            PropertyChanging?.Invoke(this,new PropertyChangingEventArgs(nameof(Name)));
            name = value;
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(nameof(Name)));
        }
    }

}
