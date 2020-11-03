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
    public class InternetCommandFactory : CommandFactoryBase
    {
        public string ConfigUrl { get; private set; }

        public InternetCommandFactory(string configFilePath)
        {
            this.ConfigUrl = configFilePath;
        }
        public override IEnumerable<ICommand> GetCommands()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(this.ConfigUrl);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            // получаем поток ответа
            Stream responseStream = response.GetResponseStream();
            //Буфер для считываемых данных
            byte[] buffer = new byte[64];
            int size = 0;

            bool isCommands = false;
            string tmpstring = "";
            var result = new List<ICommand>();
            while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                foreach (byte one in buffer)
                {
                    tmpstring += Convert.ToChar(one);
                    if (one == 13)
                    {
                        tmpstring.Trim();
                        if (isCommands == false)
                        {
                            if (tmpstring == "[Commands]\r")
                            {
                                isCommands = true;
                                tmpstring = "";
                                continue;
                            }
                            else
                                throw new ArgumentException(string.Format("Section command not first '{0}'", tmpstring));
                        }
                        var configItems = tmpstring.Split('=');
                        var commandType = configItems[0].ToLower().Trim();
                        var commandParameters = configItems[1].Split('\t');
                        var command = CreateCommand(commandType, commandParameters);
                        result.Add(command);

                        tmpstring = "";
                    }
                }
                Array.Clear(buffer,0, buffer.Length);
            }
            Console.WriteLine("");
            response.Close();
            return result;
        }
    }
}
