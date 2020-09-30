using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Lib
{
    public class PlusMonth : Command, ICommand
    {
        private DateTime d1 { get; set; }
        public PlusMonth(DateTime d1)
        {
            this.d1 = d1;
//            this.status = 0;
            this.descript = " PlusMonth ";
        }
        public override void Excecute()
        {
            this.result = this.d1.AddMonths(1);
//            this.status = 1;
        }
    }
}
