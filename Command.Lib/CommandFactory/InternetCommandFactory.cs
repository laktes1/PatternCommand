using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command.Lib.Intf;

namespace Command.Lib.CommandFactory
{
    public class InternetCommandFactory : ICommandFactory
    {
        public string ConfigUrl { get; private set; }

        public InternetCommandFactory(string configUrl)
        {
            this.ConfigUrl = configUrl;
        }
        public IEnumerable<ICommand> GetCommands()
        {
            throw new NotImplementedException();
        }
    }
}
