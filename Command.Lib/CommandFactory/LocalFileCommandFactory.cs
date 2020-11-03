using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command.Lib.Intf;

namespace Command.Lib.CommandFactory
{
    public class LocalFileCommandFactory : CommandFactoryBase
    {
        public string ConfigFilePath { get; private set; }
        public LocalFileCommandFactory(string configFilePath)
        {
            this.ConfigFilePath = configFilePath;
        }
        public override IEnumerable<ICommand> GetCommands()
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
    }
}

