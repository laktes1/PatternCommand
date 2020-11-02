using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command.Lib.Intf;

namespace Command.Lib.CommandFactory
{
    public class LocalFileCommandFactory : ICommandFactory
    {
        public string ConfigFilePath { get; private set; }

        public LocalFileCommandFactory(string configFilePath)
        {
            this.ConfigFilePath = configFilePath;
        }

        public IEnumerable<ICommand> GetCommands()
        {
            if (!File.Exists(this.ConfigFilePath))
            {
                throw new ArgumentException(string.Format("ConfigFile '{0}' does not exist", this.ConfigFilePath));
            }

            var result = new List<ICommand>();

            var configLines = File.ReadAllLines(this.ConfigFilePath);
            foreach (var configLine in configLines)
            {
                var configItems = configLine.Split('\t');

                var commandType = configItems[0];
                var commandParameters = configItems.Skip(1).ToArray();

                var command = CreateCommand(commandType, commandParameters);

                result.Add(command);
            }

            return result;
        }

        private ICommand CreateCommand(string commandType, string[] commandParameters)
        {
            switch (commandType.ToLower())
            {
                case "PlusMonth":
                    return CreatePlusMonth(commandParameters);
                case "SecToDate":
                    return CreateSecToDate(commandParameters);
                default:
                    throw new ArgumentException(string.Format(" UnsupportedCommandType: '{0}'", commandType));
            }
        }

        private ICommand CreatePlusMonth(string[] commandParameters)
        { 
            var result = new PlusMonth(Convert.ToDateTime(commandParameters.First()) );
            return result;
        }

        private ICommand CreateSecToDate(string[] commandParameters)
        {
            var result = new SecToDate(Convert.ToInt64(commandParameters.First()));
            return result;
        }
    }
}
