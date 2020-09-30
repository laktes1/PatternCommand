using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Lib
{
    public class CommandProcessor
    {
        public void ExecuteBatch(IEnumerable<ICommand> batch)
        {
            foreach (ICommand command in batch )
            {
                ExecuteCommand(command);
            }
        }
        private void ExecuteCommand(ICommand cmd)
        {
            Log(string.Format( "START time: {0} desript: {1}", DateTime.Now.ToString("HH:mm:ss.fff"), cmd.descript));
            cmd.Excecute();
            Log(string.Format("FINISH time: {0} result: {1} ", DateTime.Now.ToString("HH:mm:ss.fff"), cmd.result.ToString("dd.MM.yyyy")));
            Log(" ");
        }

        private void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
