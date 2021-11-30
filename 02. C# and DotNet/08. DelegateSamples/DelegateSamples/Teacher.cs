using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSamples
{
    public class TeacherNameChangeArgs : EventArgs
    {
        public string OldName { get; set; }
        public string NewName { get; set; }

        public TeacherNameChangeArgs(string oldName, string newName)
        {
            OldName = oldName;
            NewName = newName;
        }
    }
    public class Teacher
    {
        public event EventHandler<TeacherNameChangeArgs> TeacherNameChanged;
        private string _name;
        private string _description;

        public Teacher(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public void SetName(string newName)
        {
            var args = new TeacherNameChangeArgs(_name,newName);
            this._name = newName;
            TeacherNameChanged.Invoke(this,args);
        }
    }

    public class TeacherChangeNameLogger
    {
        public void Log(object sender, TeacherNameChangeArgs args)
        {
            Console.WriteLine($"Old name is: {args.OldName} and new name is: {args.NewName}");
        }
    }

    public class TeacherChangeNameLogger2
    {
        public void Log(object sender, TeacherNameChangeArgs args)
        {
            Console.WriteLine("Logger2");
            Console.WriteLine($"Old name is: {args.OldName} and new name is: {args.NewName}");
        }
    }
}
