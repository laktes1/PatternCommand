using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Lib
{
    public class CommandProcessor
    {
        public void ExecuteBatch(ICommand[] batch)
        {
            foreach (ICommand command in batch )
            {
                ExecuteCommand(command);
            }
        }
        public void ExecuteCommand(ICommand cmd)
        {
            Console.WriteLine("START: " + DateTime.Now.Hour+ " " + DateTime.Now.Minute + " " + DateTime.Now.Second + " " + DateTime.Now.Millisecond);
            cmd.Excecute();
            Console.WriteLine("FINISH: " + DateTime.Now.Hour + " " + DateTime.Now.Minute + " " + DateTime.Now.Second + " " + DateTime.Now.Millisecond);
            Console.WriteLine(cmd.description());
            Console.WriteLine(cmd.result);
            Console.WriteLine();
        }
    }
}
