using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Lib
{
    public class SecToDate : Command, ICommand
    {
        private double seconds { get; }
        public SecToDate(int seconds)
        {
            this.seconds = seconds;
//            this.status = 0;
            this.descript = " SecToDate ";
        }
        public override void Excecute()
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(this.seconds).ToLocalTime();
            this.result = dtDateTime;
//            this.status = 1;
        }
    }
}
