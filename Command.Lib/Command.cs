using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Lib
{
    public abstract class Command : ICommand
    {
        public DateTime result { get; set; }
        public abstract void Excecute();
        public CommandState status;
        public enum CommandState
        {
            NONE,
            creation,
            established,
            executing,
            executed,
            FAILED
        }
    }
}
