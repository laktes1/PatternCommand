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
            this.status  = CommandState.creation;
            CheckDates(dates);
            this.dates = dates;
            this.status = CommandState.established;
        }
        public override void Excecute()
        {
            this.status = CommandState.executing;
            this.result = dates.First();

            foreach (DateTime date in dates)
            {
                if (date > result)
                    result = date;
            }
            this.status = CommandState.executed;
        }
        public override string ToString()
        {
            return "Максимальная дата";
        }
    }
}
