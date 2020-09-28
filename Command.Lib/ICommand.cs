using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Lib
{
    public interface ICommand 
    {
        int status { get; }
        DateTime result { get; }
        void Excecute();
        string description();

    }
}
