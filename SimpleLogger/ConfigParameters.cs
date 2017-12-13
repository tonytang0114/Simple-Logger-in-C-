using System.Configuration;
using SimpleLogger.IService;
namespace SimpleLogger
{
    public class ConfigParameters:IConfigParam
    {
        public string Log_path { get; private set; }
        public string Archive_path { get; private set; }
        public string Log_filename { get; private set; }
        public string Log_folder { get; private set; }

        public void GetConfigSettings()
        {
            Log_path = ConfigurationManager.AppSettings["Log_path"];
            Archive_path = ConfigurationManager.AppSettings["Archive_log"];
            Log_filename = ConfigurationManager.AppSettings["Log_Filename"];
            Log_folder = ConfigurationManager.AppSettings["Log_folder"];
        }
    }
}
