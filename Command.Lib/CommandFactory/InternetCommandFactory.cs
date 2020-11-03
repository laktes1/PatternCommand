using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command.Lib.Intf;
using System.Net;
using System.IO;

namespace Command.Lib.CommandFactory
{
    public class InternetCommandFactory : ICommandFactory
    {
        public string ConfigUrl { get; private set; }

        public InternetCommandFactory(string configFilePath)
        {
            this.ConfigUrl = configFilePath;
        }
        public IEnumerable<ICommand> GetCommands()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(this.ConfigUrl);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            // получаем поток ответа
            Stream responseStream = response.GetResponseStream();
            // сохраняем файл в дисковой системе
            // создаем поток для сохранения файла
            FileStream fs = new FileStream("set.ini", FileMode.Create);
            //Буфер для считываемых данных
            byte[] buffer = new byte[64];
            int size = 0;

            while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fs.Write(buffer, 0, size);

            }
            fs.Close();
            response.Close();
            var result = new List<ICommand>();
            var path = "C:\\Users\\Serejka\\Documents\\Visual Studio 2017\\Projects\\PatternCommand\\PatternCommand\\bin\\Debug\\set.ini";
            IniFiles INI = new IniFiles(path);
            INI.GetPrivateProfileSection("Commands", path, out IEnumerable<string> Cmds);

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
            var result = new PlusMonth(Convert.ToDateTime(commandParametersIn.First()));
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
