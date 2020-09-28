using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Lib
{
    public class SecToDate : Command, ICommand
    {
        double seconds { get; set; }
        public SecToDate(int seconds)
        {
            this.seconds = seconds;
            this.status = 0;
            this.descript = " SecToDate ";
        }
        public void Excecute()
        {
            //            int year = seconds/60/60/24/30/365;
            //            this.result = new DateTime(2015, 7, 20);
            //            this.result = DateTime.FromFileTime(this.seconds);
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(this.seconds).ToLocalTime();
            this.result = dtDateTime;

        }
    }
}
