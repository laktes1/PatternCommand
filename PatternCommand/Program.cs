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
            };
                               
        }
    }
}
