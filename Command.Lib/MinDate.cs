using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Lib
{
    public class MinDate : Command
    {
        private IEnumerable<DateTime> dates { get; set; }

        public MinDate(IEnumerable<DateTime> dates)
        {
            this.dates = dates;
            //            this.status = 0;
            this.descript = " MinDate ";
        }
        public override void Excecute()
        {
            this.result = new DateTime(9999, 12, 31);

            foreach (DateTime date in dates)
            {
                if (date < result)
                    result = date;
            }
            //this.status = 1;
        }
    }
}
