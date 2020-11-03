using Command.Lib.Intf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Lib.CommandFactory
{
    abstract public class CommandFactoryBase : ICommandFactory
    {
        abstract public IEnumerable<ICommand> GetCommands();
        public ICommand CreateCommand(string commandType, string[] commandParameters)           //НЕ ПОЛУЧАЕТСЯ ПРИВАТНЫМ СДЕЛАТЬ!?
        {
            switch (commandType)
            {
                case "plusmonth":
                    return CreatePlusMonth(commandParameters);
                case "sectodate":
                    return CreateSecToDate(commandParameters);
                case "maxdate":
                    return CreateMaxDate(commandParameters);
                case "mindate":
                    return CreateMinDate(commandParameters);
                default:
                    throw new ArgumentException(string.Format(" UnsupportedCommandType: '{0}'", commandType));
            }
        }

        private ICommand CreatePlusMonth(string[] commandParametersIn)
        {
            return new PlusMonth(Convert.ToDateTime(commandParametersIn.First()));
        }

        private ICommand CreateSecToDate(string[] commandParametersIn)
        {
            return new SecToDate(Convert.ToInt64(commandParametersIn.First()));
        }
        private ICommand CreateMaxDate(string[] commandParametersIn)
        {
            var commandParametersOut = new List<DateTime>();

            foreach (string temp in commandParametersIn)
                commandParametersOut.Add(DateTime.Parse(temp));

            var result = new MaxDate(commandParametersOut);
            return result;
        }
        private ICommand CreateMinDate(string[] commandParametersIn)
        {
            var commandParametersOut = new List<DateTime>();

            foreach (string temp in commandParametersIn)
                commandParametersOut.Add(DateTime.Parse(temp));

            var result = new MinDate(commandParametersOut);
            return result;
        }
    }
}
