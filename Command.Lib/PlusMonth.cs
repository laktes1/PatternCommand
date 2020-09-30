using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Lib
{
    public class PlusMonth : Command
    {
        private DateTime date { get; set; } 
        public PlusMonth(DateTime date)
        {
            this.status = CommandState.creation;
            this.date = date;
            this.status = CommandState.established;
        }
        public override void Excecute()
        {
            this.status = CommandState.executing;
            this.result = this.date.AddMonths(1);
            this.status = CommandState.executed;
        }
    }
}
