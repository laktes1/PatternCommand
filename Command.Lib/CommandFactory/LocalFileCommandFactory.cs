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
            IniFiles INI = new IniFiles(this.ConfigFilePath);

            var result = new List<ICommand>();

            INI.GetPrivateProfileSection("Commands", this.ConfigFilePath, out IEnumerable<string> templist);
            foreach (string line in templist)
            {

                var configItems = line.Split('=');

                var commandType = configItems[0].ToLower();

                var commandParameters = configItems.Skip(1).ToArray();
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
        private ICommand CreateMaxDate(string[] commandParameters)
        {
            throw new ArgumentException(string.Format("MaxDate does not exist {0}", this.ConfigFilePath));
            //var collections = CollectionList.CreateFromCSVStringArray(commandParameters);

            //var result = new Commands.Command_Join(collections);
            //return result;
        }
        private ICommand CreateMinDate(string[] commandParameters)
        {
            throw new ArgumentException(string.Format("MinDate does not exist {0}", this.ConfigFilePath));
            //var result = new MinDate( );
            //return result;
        }

    }
}
