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
            Log(string.Format("START time: {0} desript: {1}", DateTime.UtcNow.ToString("HH:mm:ss.fff"), cmd.GetType().Name ));
            cmd.Excecute();
            Log(string.Format("FINISH time: {0} result: {1} \n", DateTime.UtcNow.ToString("HH:mm:ss.fff"), cmd.result.ToString("dd.MM.yyyy")));
        }

        private void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
