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
            this.date = date;
//            this.status = 0;
            this.descript = " PlusMonth ";
        }
        public override void Excecute()
        {
            this.result = this.date.AddMonths(1);
//            this.status = 1;
        }
    }
}
