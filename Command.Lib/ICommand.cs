using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Lib
{
    public interface ICommand 
    {
        //        int status { get; }
//        enum CommandState{get; };
        DateTime result { get; }
        string descript { get; }
        void Excecute();

    }
}
