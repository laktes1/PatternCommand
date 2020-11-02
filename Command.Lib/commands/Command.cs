using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Lib
{
    public abstract class Command : ICommand
    {
        public DateTime result { get; set ; }
        public CommandState status { get ; protected set ; }
        public abstract void Excecute();
        
        protected void CheckDates(IEnumerable< DateTime> dates)
        {
            if (dates.Count() <= 0)
                throw new Exception("Пустой список дат");
            foreach (DateTime date in dates)
            {
                CheckDate(date);
            }
        }

        protected void CheckDate(DateTime date)
        {
            if (date.ToString() == "")
                throw new Exception("Пустая дата");
        }

        protected void CheckSecs(double seconds)
        {
            if (seconds.ToString() == "")
                throw new Exception("Пустые секунды");
        }
    }
}
