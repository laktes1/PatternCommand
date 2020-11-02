using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Lib
{
    public class SecToDate : Command
    {
        private double seconds { get; }
        public SecToDate(double seconds)
        {
            this.status = CommandState.creation;
            CheckSecs(seconds);
            this.seconds = seconds;
            this.status = CommandState.established;
        }
        public override void Excecute()
        {
            this.status = CommandState.executing;
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(this.seconds);
            this.result = dtDateTime;
            this.status = CommandState.executed;
        }
        public override string ToString()
        {
            return "Секунды в дату";
        }
    }
}
