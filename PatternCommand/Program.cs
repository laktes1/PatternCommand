using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command.Lib;

namespace PatternCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            ICommand[] list1 = CreateListCommand();
            CommandProcessor CP1 = new CommandProcessor();
            CP1.ExecuteBatch(list1);
            Console.ReadLine();
        }

        private static ICommand[] CreateListCommand()
        {
            return new ICommand[] {
                new MaxDate(new DateTime(2015, 7, 20), new DateTime(2016, 7, 20)),
                new MinDate(new DateTime(2015, 7, 20), new DateTime(2016, 7, 20)),
                new PlusMonth( new DateTime(2015, 12, 20)),
                new SecToDate( 350000),
                new MaxDate(new DateTime(2010, 7, 20), new DateTime(2020, 7, 20)),
                new MinDate(new DateTime(2020, 7, 20), new DateTime(2010, 7, 20)),
                new PlusMonth( new DateTime(2015, 01, 20)),
                new SecToDate( 2365125),
                new MaxDate(new DateTime(2000, 7, 20), new DateTime(2001, 7, 20)),
                new MinDate(new DateTime(2001, 7, 20), new DateTime(2000, 7, 20)),
                new PlusMonth( new DateTime(2015, 05, 20)),
                new SecToDate( 9874562),
            };
                               
        }
    }
}
