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
            this.status = CommandState.creation;
            this.dates = dates;
            CheckDates(dates);
            this.status = CommandState.established;
        }
        public override void Excecute()
        {
            this.status = CommandState.executing;
            this.result = dates.First();

            foreach (DateTime date in dates)
            {
                if (date < result)
                    result = date;
            }

            this.status = CommandState.executed;
        }
        public override string ToString()
        {
            return "Минимальная дата";
        }
    }
}
