using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Lib
{
    public class MaxDate : ICommand
    {
        public int status { get; set ; }
        public DateTime d1 { get ; set; }
        public DateTime d2 { get ; set ; }
        public DateTime result { get; set ; }
        public MaxDate(DateTime d1, DateTime d2){
            this.d1 = d1;
            this.d2 = d2;
            this.status = 0;
        }
        public void Excecute()
        {
            if (d1 >= d2) this.result = d1;
            else this.result = d2;
            this.status = 1;
        }

        public string description()
        {
            return " maxdate ";
        }
    }
}
