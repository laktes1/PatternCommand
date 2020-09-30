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
//        public int status { get; set; }
        public enum CommandState{
        NONE,
        CREATE,
        EXECUTING,
        EXECUTE,
        FAILD}
        public string descript { get; set; }
        public abstract void Excecute();
    }
}
