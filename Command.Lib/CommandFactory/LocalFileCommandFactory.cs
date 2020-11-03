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

            IniFiles INI = new IniFiles(this.ConfigFilePath);
            INI.GetPrivateProfileSection("Commands", this.ConfigFilePath, out IEnumerable<string> Cmds);

            foreach (string line in Cmds)
            {
                var configItems = line.Split('=');
                var commandType = configItems[0].ToLower();
                var commandParameters = configItems[1].Split('\t');          
                var command = CreateCommand(commandType, commandParameters);
                result.Add(command);
            }
            return result;
        }

        private ICommand CreateCommand(string commandType, string[] commandParameters)
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
            var result = new PlusMonth(Convert.ToDateTime(commandParametersIn.First()) );
            return result;
        }

        private ICommand CreateSecToDate(string[] commandParametersIn)
        {
            var result = new SecToDate(Convert.ToInt64(commandParametersIn.First()));
            return result;
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

