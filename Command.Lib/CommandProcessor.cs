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
            Console.WriteLine("START: " + DateTime.Now.ToString("HH:mm:ss:fff"));
            cmd.Excecute();
            Console.WriteLine("FINISH: " + DateTime.Now.ToString("HH:mm:ss:fff"));
            Console.WriteLine(cmd.descript);
            Console.WriteLine(cmd.result.ToString("dd:MM:yyyy"));
            Console.WriteLine();
        }
    }
}
