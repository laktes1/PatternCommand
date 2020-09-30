using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Lib
{
    public class MaxDate : Command
    {
        private IEnumerable<DateTime> dates { get ; set; }
        
        public MaxDate(IEnumerable<DateTime> dates)
        {
            this.dates = dates;
//            this.status = 0;
            this.descript = " MaxDate ";
        }
        public override void Excecute()
        {
            this.result = new DateTime(0001, 01, 01);

            foreach (DateTime date in dates)
            {
                if (date > result)
                    result = date;
            }

        }
    }
}
