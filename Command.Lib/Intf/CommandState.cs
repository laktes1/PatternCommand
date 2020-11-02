using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Lib
{
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

